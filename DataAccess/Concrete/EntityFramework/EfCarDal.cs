using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entites.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext> ,ICarDal
    {
     


        private IQueryable<CarDetailDto> GetCarDetailQuery(ReCapProjectContext context )
        {
            return from c in context.Cars
                   join co in context.Colors on c.ColorId equals co.ColorId
                   join cl in context.CarClasses on c.ClassId equals cl.ClassId
                   join b in context.Brands on c.BrandId equals b.BrandId
                   join m in context.Models on c.ModelId equals m.ModelId
                   join f in context.FuelTypes on c.FuelId equals f.FuelId
                   join g in context.GearTypes on c.GearId equals g.GearId
                   join l in context.RentalLocations on c.LocationId equals l.LocationId
                   select new CarDetailDto
                   {
                       CarId = c.CarId,
                       ClassName = cl.ClassName,
                       BrandName = b.BrandName,
                       ModelName = m.ModelName,
                       FuelTypeName = f.FuelName,
                       GearTypeName = g.GearName,
                       ColorName = co.ColorName,
                       ModelYear = c.ModelYear,
                       DailyPrice = c.DailyPrice,
                       Description = c.Description,
                       FindexScore = c.FindexScore,
                       ColorId = c.ColorId,
                       BrandId = c.BrandId,
                       FuelId = c.FuelId,
                       GearId = c.GearId,
                       ModelId = c.ModelId,
                       LocationId = c.LocationId,
                       
                   };
        }

        public List<CarDetailDto> GetCarDetails(CarDetailFilter carDetailFilter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context);

                result = result.Where(c =>
                       !(context.Rentals.Any(r => r.CarId == c.CarId
                          && ((carDetailFilter.RentDate.HasValue && r.ReturnDate > carDetailFilter.RentDate)
                          || (carDetailFilter.ReturnDate.HasValue && r.RentDate < carDetailFilter.ReturnDate)))));
                result = carDetailFilter.LocationId.HasValue ? result.Where(c => c.LocationId == carDetailFilter.LocationId) : result;
                result = carDetailFilter.BrandId.HasValue ? result.Where(c => c.BrandId == carDetailFilter.BrandId) : result;
                result = carDetailFilter.ColorId.HasValue ? result.Where(c => c.ColorId == carDetailFilter.ColorId) : result;
                result = carDetailFilter.FuelId.HasValue ? result.Where(c => c.FuelId == carDetailFilter.FuelId) : result;
                result = carDetailFilter.GearId.HasValue ? result.Where(c => c.GearId == carDetailFilter.GearId) : result;
                result = carDetailFilter.ModelId.HasValue ? result.Where(c => c.ModelId == carDetailFilter.ModelId) : result;
               




                return result.ToList();

            }
        }


        public CarDetailDto GetCarDetailsByCarId(int carId)  
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).Where(c => c.CarId == carId).SingleOrDefault();
                return result;

            }
        }


    }
}
