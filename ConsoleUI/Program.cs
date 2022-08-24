using Business.Abstract;
using Business.Concrete;
using Entites.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            //Veri eklemeler. ID otomatik artan olarak düzenlenmeli...

            //carManager.Add(new Car { Id = 1, BrandId = 5, ColorId = 3, DailyPrice = 100, ModelYear = 2012, Description = "Renault Sedan" });
            //carManager.Add(new Car { Id = 2, BrandId = 5, ColorId = 3, DailyPrice = 100, ModelYear = 2012, Description = "Renault Sedan" });
            //carManager.Add(new Car { Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 200, ModelYear = 2012, Description = "BMW Sedan" });
            //carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 400, ModelYear = 2015, Description = "Renault Hatchback" });
            //carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 200, ModelYear = 2016, Description = "Opel Sedan" });
            //carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 400, ModelYear = 2014, Description = "Renault Sedan" });
            //carManager.Add(new Car { Id = 7, BrandId = 2, ColorId = 2, DailyPrice = 100, ModelYear = 2014, Description = "Mercedes Sedan" });

            //Brand Id ye göre filtreleme çalışıyor.

            //foreach (var car in carManager.GetCarsByBrandId(3))
            //{
            //    Console.WriteLine("{0} {1}",car.Id, car.Description);
            //}

            //Color Id ye göre filtreleme çalışıyor.

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine("{0} {1}", car.Id, car.Description);
            //}

        }
    }
}
