using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Business.Concrete
{
    public class FuelTypeManager : IFuelTypeService
    {
        IFuelTypeDal _fuelTypeDal;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal;
        }
        public IResult Add(FuelType fuelType)
        {
            _fuelTypeDal.Add(fuelType);
            return new SuccessResult(Messages.FuelTypeAdded);
        }

        public IResult Delete(FuelType fuelType)
        {
            _fuelTypeDal.Delete(fuelType);
            return new SuccessResult(Messages.FuelTypeDeleted);
        }

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll(), Messages.FuelTypeListed);
        }

        public IDataResult<FuelType> GetById(int fuelTypeId)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=>f.Id == fuelTypeId), Messages.FuelTypeListed);
        }

        public IResult Update(FuelType fuelType)
        {
            _fuelTypeDal.Update(fuelType);
            return new SuccessResult(Messages.FuelTypeUpdated);
        }
    }
}
