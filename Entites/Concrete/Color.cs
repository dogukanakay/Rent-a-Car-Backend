using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entites.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Color : Entity<int>
    {
       
        public string ColorName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
