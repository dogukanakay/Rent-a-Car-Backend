using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Filters
{
    public class CarDetailFilter :IFilter
    {
        // Filters Tools
        public int? LocationId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? GearId { get; set; }
        public int? FuelId { get; set; }
        public int? ColorId { get; set; }
    }
}
