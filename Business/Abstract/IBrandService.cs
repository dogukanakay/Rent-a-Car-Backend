using Core.Utilities.Results;
using Entities.Requests.Create;
using Entities.Requests.Update;
using Entities.Responses.Create;
using Entities.Responses.GetList;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<CreateBrandResponse> Add(CreateBrand createBrand);
        IDataResult<List<GetListBrandResponse>> GetAll();
        IResult Delete(int id);
        IResult Update(UpdateBrand updateBrand);
        IResult Update(UpdateBrand updateBrand, DateTime dateTime);
    }
}
