﻿using Core.Utilities.Results;
using Entites.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        
    }
}
