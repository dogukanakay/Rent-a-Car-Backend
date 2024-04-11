using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IPaymentService _paymentService;
        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService)
        {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        
        public IResult Add(Rental rental, Payment payment)
        {
            if(IsRentable(rental).Success)
            {
                rental.CreatedDate = DateTime.Now;
                _rentalDal.Add(rental);

                payment.RentId = rental.Id;

                _paymentService.Add(payment);

                
                return new SuccessResult(Messages.ExampleSuccessMessage);
            }
            else
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            } 
           
           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);

        }

        public IDataResult<Rental> Get(int rentId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentId));
        }
        [CacheAspect]
        [PerformanceAspect(0)]
        
        //[LogAspect(typeof(FileLogger))]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ExampleSuccessMessage);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(RentalDetailFilter rentalDetailFilter)
        {
           
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(rentalDetailFilter), Messages.ExampleSuccessMessage);

        }

        public IDataResult<RentalDetailDto> GetRentalDetailsByRentId(int rentId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailsByRentId(rentId), Messages.ExampleSuccessMessage);

        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var rentCar = _rentalDal.Get(c => c.CarId == rental.CarId && rental.RentDate <= c.ReturnDate &&
                    rental.ReturnDate >= c.RentDate );
               

            if(rentCar ==null)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
                
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }
    }
}
