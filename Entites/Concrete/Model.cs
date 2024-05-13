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
    public class Model : Entity<int>
    {
        public int BrandId { get; set; }
        public string ModelName { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
