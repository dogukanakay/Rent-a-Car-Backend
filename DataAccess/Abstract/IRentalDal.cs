using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
       Rental GetByCarId(int id);
    }
}
