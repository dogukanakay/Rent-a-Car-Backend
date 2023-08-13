using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalLocationManager : IRentalLocationService
    {
        IRentalLocationDal _rentalLocationDal;
        public RentalLocationManager(IRentalLocationDal rentalLocationDal)
        {
            _rentalLocationDal = rentalLocationDal;
        }
        public IResult Add(RentalLocation rentalLocation)
        {
            _rentalLocationDal.Add(rentalLocation);
            return new SuccessResult(Messages.RentalLocaitonAdded);
        }

        public IResult Delete(RentalLocation rentalLocation)
        {
            _rentalLocationDal.Delete(rentalLocation);
            return new SuccessResult(Messages.RentalLocaitonDeleted);
        }

        public IDataResult<List<RentalLocation>> GetAll()
        {
            return new SuccessDataResult<List<RentalLocation>>(_rentalLocationDal.GetAll(), Messages.RentalLocaitonListed); 
        }

        public IDataResult<RentalLocation> GetById(int rentalLocationId)
        {
            return new SuccessDataResult<RentalLocation>(_rentalLocationDal.Get(r => r.LocationId == rentalLocationId), Messages.RentalLocaitonListed);
        }

        public IResult Update(RentalLocation rentalLocation)
        {
            _rentalLocationDal.Update(rentalLocation);
            return new SuccessResult(Messages.RentalLocaitonUpdated);
        }
    }
}
