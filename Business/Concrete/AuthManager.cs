﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Tokens;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ICustomerService _customerService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService customerService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _customerService = customerService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult IsAuthenticated()
        {
            return new SuccessResult("Bu sayfaya erişimi var.");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
         
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                status = true

            };
            _userService.Add(user);
            Random random = new Random();
            var customer = new Customer
            {
                UserId = _userService.GetByEmail(userForRegisterDto.Email).Data.Id,
                CompanyName = userForRegisterDto.CompanyName,
                FindexScore = random.Next(0,1901) // GEÇİCİ OLARAK BÖYLE - GERÇEK VEYA FAKE FİNDEX SERVİSİ KULLANILACAK

            };

            _customerService.Add(customer);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult SetNewPassword(SetNewPasswordForUserDto setNewPasswordForUserDto, string email)
        {
            byte[] passwordHash, passwordSalt;
            var user = _userService.GetByEmail(email).Data;
            if (!HashingHelper.VerifyPasswordHash(setNewPasswordForUserDto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(setNewPasswordForUserDto.NewPassword, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var result = _userService.Update(user);
            if(result.Success)
            {
                return new SuccessResult(Messages.PasswordUpdated);
            }
            return new ErrorResult(Messages.PasswordUpdatedError);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
