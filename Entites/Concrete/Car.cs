using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Car:Entity<int>
    {
        public int LocationId { get; set; }
        public int ClassId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ModelYear { get; set; }
        public int GearId { get; set; }
        public int FuelId { get; set; }
        public int ColorId { get; set; }
        public double DailyPrice { get; set; }
        public int FindexScore { get; set; }
        public string Description { get; set; }

        public virtual RentalLocation RentalLocation { get; set; }
        public virtual CarClass CarClass { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        public virtual GearType GearType { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Color Color { get; set; }


        public virtual ICollection<CarImage> CarImages  { get; set;}
        public virtual ICollection<Rental> Rentals { get; set; }



    }
}
