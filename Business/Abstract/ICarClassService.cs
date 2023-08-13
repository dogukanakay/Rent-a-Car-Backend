using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarClassService
    {
        IResult Add(CarClass carClass);
        IResult Delete(CarClass carClass);
        IResult Update(CarClass carClass);

        IDataResult<List<CarClass>> GetAll();
        IDataResult<CarClass> GetById(int carClassId);
    }

}
