using Business.Abstract;
using Business.Concrete;
using Entites.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+" "+car.Description);
            }
            


            Console.WriteLine("*********************************************");
            Console.WriteLine("TEST");
            Console.WriteLine("*********************************************");


           
            carManager.Add(new Car { Id = 9, BrandId = 3, ColorId = 2, DailyPrice = 500, Description = "Yeni 2021", ModelYear = 2021 });
            carManager.Delete(new Car { Id = 2 });
            carManager.Update(new Car { Id = 1, BrandId = 20, ColorId = 30, ModelYear = 2012, Description = "Guncellendi", DailyPrice = 1000 });




            foreach (var car in carManager.GetAll())
            {
                
                Console.WriteLine(car.Id+" "+car.Description);
            }
            Console.WriteLine("*************************************");
            Console.WriteLine("ID'ye gore getirtme----1----");
            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
