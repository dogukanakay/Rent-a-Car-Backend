using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalLocationService
    {
        IResult Add(RentalLocation rentalLocation);
        IResult Delete(RentalLocation rentalLocation);
        IResult Update(RentalLocation rentalLocation);

        IDataResult<List<RentalLocation>> GetAll();
        IDataResult<RentalLocation> GetById(int rentalLocationId);
    }

}
