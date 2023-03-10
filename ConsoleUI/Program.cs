using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental
            {
                CarId = 3, CustomerId=1, RentDate = DateTime.Now, ReturnDate = DateTime.Now,
            });

        }

    }
}
