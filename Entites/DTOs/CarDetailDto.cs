﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string ClassName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string GearTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int FindexScore { get; set; }
        public string Description { get; set; }
    

    }
}
