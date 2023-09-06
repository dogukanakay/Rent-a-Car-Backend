using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from claims in context.OperationClaims
                             join userclaims in context.UserOperationClaims
                             on claims.Id equals userclaims.OperationClaimId
                             where userclaims.UserId == user.Id
                             select new OperationClaim { Id = claims.Id, Name = claims.Name };
                return result.ToList();
            }
        }

        public UserDetailDto GetDetailsByEmail(string email)
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers on u.Id equals c.UserId
                             where u.Email == email
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 FindexScore = c.FindexScore

                             };

                return result.FirstOrDefault();
            }
        }
    }
}
