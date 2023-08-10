using Core.Utilities.Results;
using Entites.Concrete;
using Entities.DTOs;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByCarId(int carId);
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails(CarDetailFilter carDetailFilter);
        


    }
}
