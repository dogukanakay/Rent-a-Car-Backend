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
    public interface IColorService
    {
        IResult Add(Color color);
        IDataResult<List<Color>> GetAll();
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
