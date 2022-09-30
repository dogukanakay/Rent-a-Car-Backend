using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1,BrandId=2,ColorId=1,DailyPrice=300,ModelYear=2010,Description="Renault Sedan"},
                new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=500,ModelYear=2012,Description="BMW Sedan"},
                new Car{Id=3,BrandId=1,ColorId=3,DailyPrice=600,ModelYear=2012,Description="Audi Sedan"},
                new Car{Id=4,BrandId=3,ColorId=4,DailyPrice=200,ModelYear=2016,Description="BMW Sedan"},
                new Car{Id=5,BrandId=2,ColorId=1,DailyPrice=400,ModelYear=2016,Description="Renault Sedan"},
                new Car{Id=6,BrandId=3,ColorId=2,DailyPrice=300,ModelYear=2011,Description="Opel Sedan"},
                new Car{Id=7,BrandId=2,ColorId=2,DailyPrice=400,ModelYear=2017,Description="Renault Sedan"},
                new Car{Id=8,BrandId=1,ColorId=3,DailyPrice=600,ModelYear=2011,Description="Audi Sedan"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(x => x.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }

       
    }
}
