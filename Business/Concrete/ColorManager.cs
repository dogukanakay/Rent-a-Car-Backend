﻿using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ExampleSuccessMessage);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ExampleSuccessMessage);
        }
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c=> c.ColorId == id));
        }
    }
}
