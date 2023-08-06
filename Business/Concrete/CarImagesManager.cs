using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImages)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult("Resim başarıyla yüklendi.");
        }

        public IResult Delete(CarImage carImages)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImages)
        {

            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.CarId == id));
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage> { new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "default.jpg" } };
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
