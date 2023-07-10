using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Messages.ExampleSuccessMessage);
                                    
        }
        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetailsByBrandId(brandId), Messages.ExampleSuccessMessage);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetailsColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetailsByColorId(colorId), Messages.ExampleSuccessMessage);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(), Messages.ExampleSuccessMessage);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails(), Messages.ExampleSuccessMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandIdAndColorId(brandId, colorId), Messages.ExampleSuccessMessage);
        }
    }
}
