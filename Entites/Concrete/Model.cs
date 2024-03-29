﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        [Key]
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
    }
}
