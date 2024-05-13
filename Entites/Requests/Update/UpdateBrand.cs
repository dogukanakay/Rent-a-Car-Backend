﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests.Update
{
    public class UpdateBrand : IRequest
    {
        public int Id { get; set; }
        public string BrandName  { get; set; }
    }
}
