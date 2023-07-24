using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (_rentalDal.GetByCarId(rental.CarId) == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.ExampleSuccessMessage);
            }
            else if (_rentalDal.GetByCarId(rental.CarId).ReturnDate == null)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }
           
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);

        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
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

        public bool IsRentable(int carId,DateTime rentDate, DateTime returnDate)
        {
            var rentCar = _rentalDal.GetAll().Where(
                c => c.CarId == carId && rentDate<=c.ReturnDate && returnDate>=c.RentDate);
            if(rentCar.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }
    }
}
