﻿using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailsByColorId(int colorId);
        List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId);

    }
}
