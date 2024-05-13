using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;
using Entites.Concrete;
namespace Entities.Concrete
{
    public class FuelType : Entity<int>
    {
       
        public string FuelName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
