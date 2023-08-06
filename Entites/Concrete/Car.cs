using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int CarId { get; set; }
        public int ClassId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ModelYear { get; set; }
        public int GearTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int ColorId { get; set; }
        public double DailyPrice { get; set; }
        public int FindexScore { get; set; }
        public string Description { get; set; }

    }
}
