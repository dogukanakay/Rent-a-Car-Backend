using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 FindexScore = cu.FindexScore
                                 
                             };
                return result.ToList();
            }
        }
    }
}
