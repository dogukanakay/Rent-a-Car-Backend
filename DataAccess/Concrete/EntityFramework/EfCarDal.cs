using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext> ,ICarDal
    {
      
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id  
                             select new CarDetailDto { CarId = c.Id, CarName = c.Description ,BrandName = b.Name, ColorName = co.Name, ModelYear = c.ModelYear ,DailyPrice = c.DailyPrice, BrandId = b.Id, ColorId = co.Id };

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where c.BrandId == brandId
                             select new CarDetailDto { CarId = c.Id, CarName = c.Description, BrandName = b.Name, ColorName = co.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, BrandId = b.Id, ColorId = co.Id };

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where c.BrandId == brandId && c.ColorId == colorId
                             select new CarDetailDto { CarId = c.Id, CarName = c.Description, BrandName = b.Name, ColorName = co.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, BrandId = b.Id, ColorId = co.Id };

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where c.ColorId == colorId
                             select new CarDetailDto { CarId = c.Id, CarName = c.Description, BrandName = b.Name, ColorName = co.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, BrandId = b.Id, ColorId = co.Id };

                return result.ToList();

            }
        }
    }
}
