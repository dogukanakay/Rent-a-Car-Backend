using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Requests.Create;
using Entities.Requests.Update;
using Entities.Responses.Create;
using Entities.Responses.GetById;
using Entities.Responses.GetList;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal= brandDal;
            _mapper= mapper;
        }
        [CacheRemoveAspect("IBrandService.Get")]
        public IDataResult<CreateBrandResponse> Add(CreateBrand createBrand)
        {
            Brand brand = _mapper.Map<Brand>(createBrand);
            _brandDal.Add(brand);
            CreateBrandResponse createBrandResponse = _mapper.Map<CreateBrandResponse>(brand);
            return new SuccessDataResult<CreateBrandResponse>(createBrandResponse,Messages.ExampleSuccessMessage);
        }
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(int id)
        {
           
            var brand = _brandDal.Get(b => b.Id == id);
            var updateBrand = _mapper.Map<UpdateBrand>(brand);
            Update(updateBrand, DateTime.Now);
            return new SuccessResult(brand.BrandName +" "+Messages.BrandDeleted);
        }
        [CacheAspect]
        public IDataResult<List<GetListBrandResponse>> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll(b=>!b.DeletedDate.HasValue);
            List<GetListBrandResponse> getListBrandResponses = new List<GetListBrandResponse>();

            foreach (var brand in brands)
            {
                getListBrandResponses.Add(_mapper.Map<GetListBrandResponse>(brand));
            }
            return new SuccessDataResult<List<GetListBrandResponse>>(getListBrandResponses,Messages.ExampleSuccessMessage);
        }
        [CacheRemoveAspect("IBrandService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(UpdateBrand updateBrand)
        {
            Brand brand = _mapper.Map<Brand>(updateBrand);
            brand.ModifiedDate = DateTime.Now;
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(UpdateBrand updateBrand, DateTime dateTime)
        {
            Brand brand = _mapper.Map<Brand>(updateBrand);
            brand.DeletedDate = dateTime;
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        public IDataResult<GetByIdBrandReponse> GetById(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            var getByIdBrandResponse = _mapper.Map<GetByIdBrandReponse>(brand);
            return new SuccessDataResult<GetByIdBrandReponse>(getByIdBrandResponse);
        }
    }
}
