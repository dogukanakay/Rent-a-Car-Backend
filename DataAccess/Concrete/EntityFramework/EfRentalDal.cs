using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Filters;
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
        private IQueryable<RentalDetailDto> GetRentalDetailQuery(ReCapProjectContext context)
        {
            return from c in context.Cars
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
                             RentId = r.RentId,
                             CarId = r.CarId,
                             BrandName = b.BrandName,
                             CustomerName = u.FirstName + " " + u.LastName,
                             RentDate = r.RentDate,
                             ReturnDate = r.ReturnDate,
                             ReturnDateActual = r.ReturnDateActual,
                             FuelTypeName = f.FuelName,
                             GearTypeName = g.GearName,
                             ModelName = m.ModelName,
                             TotalPrice = r.TotalPrice,
                             CustomerId = r.CustomerId,

                         };
        }
        public RentalDetailDto GetRentalDetailsByRentId(int rentId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetRentalDetailQuery(context).Where(r => r.RentId == rentId);
                return result.SingleOrDefault();
            }
        }

        public List<RentalDetailDto> GetRentalDetails(RentalDetailFilter rentalDetailFilter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = GetRentalDetailQuery(context);

                result = rentalDetailFilter.CarId.HasValue ? result.Where(r => r.CarId == rentalDetailFilter.CarId): result;
                result = rentalDetailFilter.CustomerId.HasValue ? result.Where(r=> r.CustomerId == rentalDetailFilter.CustomerId):result;

                return result.ToList();
                             
                             
            }
        }

       
    }
}
