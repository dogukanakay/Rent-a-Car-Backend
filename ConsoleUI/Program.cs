using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            //CarCrudTESTS(carManager);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //BrandCrudTESTS(brandManager);

            ColorManager colorManager = new ColorManager(new EfColorDal());

            //ColorCrudTESTS(colorManager);


            //CarName, BrandName, ColorName, DailyPrice tablosunu getirtme (Dto ile 3 lü join)

            //DtoTEST(carManager);

            carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 200, Description = "clio", ModelYear = 19299 });
            //brandManager.Add(new Brand { Name = "BMW" });
            //colorManager.Add(new Color { Name = "White" });

        }

        private static void DtoTEST(CarManager carManager)
        {
            //CarName, BrandName, ColorName, DailyPrice tablosunu getirtme (Dto ile 3 lü join)
            var carDetails = carManager.GetCarDetails();
            foreach (CarDetailDto carDetail in carDetails.Data)
            {
                Console.WriteLine(carDetail.CarName + " " + carDetail.BrandName + " " + carDetail.ColorName + " " + carDetail.DailyPrice);
            }
        }

        private static void ColorCrudTESTS(ColorManager colorManager)
        {
            //Color Ekleme testi

            colorManager.Add(new Color { Id = 1, Name = "White" });
            colorManager.Add(new Color { Id = 2, Name = "Black" });
            colorManager.Add(new Color { Id = 3, Name = "Brown" });
            colorManager.Add(new Color { Id = 4, Name = "Silver" });
            colorManager.Add(new Color { Id = 5, Name = "Chrome" });

            //Color Listeleme testi 
            var colors = colorManager.GetAll();
            foreach (var color in colors.Data)
            {
                Console.WriteLine(color.Name);
            }

            //Color Update testi

            colorManager.Update(new Color { Id = 3, Name = "Grey" });

            //Color Silme testi

            colorManager.Add(new Color { Id = 6, Name = "Silinecek" });
            colorManager.Delete(new Color { Id = 6 });

            //Color Id'ye göre getirme

            var color1 = colorManager.GetById(3);
            Console.WriteLine(color1.Data.Name);
        }

        private static void BrandCrudTESTS(BrandManager brandManager)
        {
            //Brand Ekleme testi

            brandManager.Add(new Brand { Id = 1, Name = "Renault" });
            brandManager.Add(new Brand { Id = 2, Name = "BMW" });
            brandManager.Add(new Brand { Id = 3, Name = "Opel" });
            brandManager.Add(new Brand { Id = 4, Name = "Mercedes" });
            brandManager.Add(new Brand { Id = 5, Name = "Volvo" });
            brandManager.Add(new Brand { Id = 6, Name = "TEST SILINECEK" });

            //Brand Listeleme testi

            var brands = brandManager.GetAll();
            foreach (var brand in brands.Data)
            {
                Console.WriteLine(brand.Name);
            }


            //Brand Update testi

            brandManager.Update(new Brand { Id = 5, Name = "Tesla" });


            //Brand Silme testi

            brandManager.Delete(new Brand { Id = 6 });


            //Brand Id ye göre getirme
            var brand1 = brandManager.GetById(2);
            Console.WriteLine(brand1.Data.Name);
        }

        private static void CarCrudTESTS(CarManager carManager)
        {
            //Veri eklemeler. ID otomatik artan olarak düzenlendi...

            carManager.Add(new Car {BrandId = 3, ColorId = 3, DailyPrice = 100, ModelYear = 2012, Description = "Astra 1.6" });
            carManager.Add(new Car {BrandId = 1, ColorId = 3, DailyPrice = 100, ModelYear = 2012, Description = "Megan 1.6" });
            carManager.Add(new Car {BrandId = 2, ColorId = 2, DailyPrice = 200, ModelYear = 2012, Description = "M5" });
            carManager.Add(new Car {BrandId = 1, ColorId = 1, DailyPrice = 400, ModelYear = 2015, Description = "Megan 2.0" });
            carManager.Add(new Car {BrandId = 3, ColorId = 1, DailyPrice = 200, ModelYear = 2016, Description = "Insigna 1.2" });
            carManager.Add(new Car {BrandId = 1, ColorId = 3, DailyPrice = 400, ModelYear = 2014, Description = "Clio 1.0" });
            carManager.Add(new Car {BrandId = 4, ColorId = 2, DailyPrice = 100, ModelYear = 2014, Description = "G63" });

            //Brand Id ye göre filtreleme çalışıyor.

            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine("{0} {1}", car.Id, car.Description);
            }

            //Color Id ye göre filtreleme çalışıyor.

            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine("{0} {1}", car.Id, car.Description);
            }

            // Silme testi...
            carManager.Add(new Car { Id = 8, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2014, Description = "Msadas" });
            carManager.Delete(new Car { Id = 8 });
        }
    }
}
