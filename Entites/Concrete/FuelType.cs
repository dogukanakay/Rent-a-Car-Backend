using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Entities.Concrete
{
    public class FuelType : IEntity
    {
        [Key]
        public int FuelId { get; set; }
        public string FuelName { get; set; }
    }
}
