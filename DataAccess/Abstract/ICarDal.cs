using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(CarDetailFilter carDetailFilter);

        CarDetailDto GetCarDetailsByCarId(int carId);
        

    }
}
