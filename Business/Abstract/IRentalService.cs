using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        public IResult Add(Rental rental, Payment payment);
        public IResult Delete(Rental rental);
        public IResult Update(Rental rental);
        public IDataResult<List<Rental>> GetAll();
        public IDataResult<Rental> Get(int rentId);
        public IDataResult<List<RentalDetailDto>> GetRentalDetails(RentalDetailFilter rentalDetailFilter);
        public IDataResult<RentalDetailDto> GetRentalDetailsByRentId(int rentId);
        public IResult IsRentable(Rental rental);

    }
}
