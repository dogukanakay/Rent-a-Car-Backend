using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
