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
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        
        public IResult Add(Rental rental)
        {
            if(IsRentable(rental).Success)
            {
                _rentalDal.Add(rental); 
                return new SuccessResult(Messages.ExampleSuccessMessage);
            }
            else
            {
                return new ErrorResult(Messages.ExampleErrorMessage);
            }
           
           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);

        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentId == id));
        }
        [CacheAspect]
        [PerformanceAspect(0)]
        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ExampleSuccessMessage);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.ExampleSuccessMessage);

        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var rentCar = _rentalDal.Get(c => c.CarId == rental.CarId && rental.RentDate <= c.ReturnDate &&
                    rental.ReturnDate >= c.RentDate && rental.ReturnDateActual >= c.RentDate);
               

            if(rentCar == null)
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
