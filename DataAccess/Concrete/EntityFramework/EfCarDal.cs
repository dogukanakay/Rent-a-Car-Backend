using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entites.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext> ,ICarDal
    {
     


        private IQueryable<CarDetailDto> GetCarDetailQuery(ReCapProjectContext context)
        {
            return from c in context.Cars
                   join co in context.Colors on c.ColorId equals co.ColorId
                   join cl in context.CarClasses on c.ClassId equals cl.ClassId
                   join b in context.Brands on c.BrandId equals b.BrandId
                   join m in context.Models on c.ModelId equals m.ModelId
                   join f in context.FuelTypes on c.FuelTypeId equals f.FuelId
                   join g in context.GearTypes on c.GearTypeId equals g.GearId
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
                       FuelId = c.FuelTypeId,
                       GearId = c.GearTypeId,
                       ModelId = c.ModelId
                   };
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).ToList();

                return result;

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).Where(c=>c.BrandId ==brandId ).ToList();
                return result;

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList();
                return result;

            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).Where(c => c.ColorId == colorId).ToList();
                return result;

            }
        }

        public CarDetailDto GetCarDetailsByCarId(int carId)  ///daha sonra buraları düzenle list to cardetaildto yapmak gerekiyor.
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetCarDetailQuery(context).Where(c => c.CarId == carId).SingleOrDefault();
                return result;

            }
        }
    }
}
