using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
        RentalDetailDto GetRentalDetailsByRentId(int rentId);
        List<RentalDetailDto> GetRentalDetails(RentalDetailFilter rentalDetailFilter);
        
    }
}
