using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Filters
{
    public class RentalDetailFilter:IFilter
    {
        public int? CarId { get; set; }
        public int? CustomerId { get; set; }
    }
}
