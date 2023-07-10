using Core.Utilities.Results;
using Entites.Concrete;
using Entities.DTOs;
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
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<List<Car>> GetAll();
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
