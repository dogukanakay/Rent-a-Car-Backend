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
                             on c.ColorId equals co.ColorId
                             join cl in context.CarClasses
                             on c.ClassId equals cl.ClassId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId 
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
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
                             };

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cl in context.CarClasses
                             on c.ClassId equals cl.ClassId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
                             where c.BrandId == brandId
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
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cl in context.CarClasses
                             on c.ClassId equals cl.ClassId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
                             where c.BrandId == brandId && c.ColorId == colorId
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
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cl in context.CarClasses
                             on c.ClassId equals cl.ClassId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
                             where c.ColorId == colorId
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
                             };
                return result.ToList();

            }
        }

        public CarDetailDto GetCarDetailsByCarId(int carId)  ///daha sonra buraları düzenle list to cardetaildto yapmak gerekiyor.
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cl in context.CarClasses
                             on c.ClassId equals cl.ClassId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
                             where c.CarId == carId
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
                             };
                return result.Single();

            }
        }
    }
}
