using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color : EntityBase<int>
    {
       
        public string ColorName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
