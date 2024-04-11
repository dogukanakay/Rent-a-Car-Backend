﻿using Core.Entities.Abstract;
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
    public class Brand:EntityBase<int>
    {
        public string BrandName { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
