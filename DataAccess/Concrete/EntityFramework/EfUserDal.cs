using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    }
}
