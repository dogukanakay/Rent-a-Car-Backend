using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:Entity<int>
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }

        public virtual Car Car { get; set; }

    }
}
