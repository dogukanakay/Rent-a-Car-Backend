using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult Add(User user);
        public IResult Delete(User user);
        public IResult Update(User user);
        public IDataResult<List<User>> GetAll();
        public IDataResult<List<OperationClaim>> GetClaims(User user);
        public IDataResult<User> GetByEmail(string email);
        public IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        public IDataResult<User> GetByUserId(int userId);
       
    }
}
