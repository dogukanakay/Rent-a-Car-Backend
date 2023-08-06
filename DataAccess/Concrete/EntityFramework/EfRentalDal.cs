using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public Rental GetByCarId(int id)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = context.Rentals.FirstOrDefault(r => r.CarId == id && r.ReturnDate==null);
                return result;
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join g in context.GearTypes
                             on c.GearTypeId equals g.GearId
                             join f in context.FuelTypes
                             on c.FuelTypeId equals f.FuelId
                             join m in context.Models
                             on c.ModelId equals m.ModelId

                             select new RentalDetailDto
                             {
                                 
                                 BrandName = b.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ReturnDateActual = r.ReturnDateActual,
                                 FuelTypeName = f.FuelName,
                                 GearTypeName = g.GearName,
                                 ModelName = m.ModelName,
                                 TotalPrice = r.TotalPrice
                               
                             };
                             
                return result.ToList();
                             
                             
            }
        }
    }
}
