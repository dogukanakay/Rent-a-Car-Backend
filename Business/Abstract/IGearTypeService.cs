using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGearTypeService
    {
        IResult Add(GearType gearType);
        IResult Delete(GearType gearType);
        IResult Update(GearType gearType);

        IDataResult<List<GearType>> GetAll();
        IDataResult<GearType> GetById(int gearTypeId);
    }

}
