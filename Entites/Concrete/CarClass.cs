using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarClass : IEntity
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
