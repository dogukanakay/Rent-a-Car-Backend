using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarClassManager : ICarClassService
    {
        ICarClassDal _carClassDal;

        public CarClassManager(ICarClassDal carClassDal)
        {
            _carClassDal = carClassDal;
        }
        [CacheRemoveAspect("ICarClassService.Get")]
        public IResult Add(CarClass carClass)
        {
            _carClassDal.Add(carClass);
            return new SuccessResult(Messages.CarsClassAdded);
        }
        [CacheRemoveAspect("ICarClassService.Get")]
        public IResult Delete(CarClass carClass)
        {
            _carClassDal.Delete(carClass);
            return new SuccessResult(Messages.CarsClassDeleted);
        }
        [CacheAspect]
        public IDataResult<List<CarClass>> GetAll()
        {
            return new SuccessDataResult<List<CarClass>>(_carClassDal.GetAll(),Messages.CarsClassListed) ;
        }

        public IDataResult<CarClass> GetById(int carClassId)
        {
            return new SuccessDataResult<CarClass>(_carClassDal.Get(c => c.Id == carClassId), Messages.CarsClassListed);
        }
        [CacheRemoveAspect("ICarClassService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(CarClass carClass)
        {
            _carClassDal.Update(carClass);

            return new SuccessResult(Messages.CarsClassUpdated);
        }
    }
}
