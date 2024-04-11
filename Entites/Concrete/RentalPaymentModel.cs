using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RentalPaymentModel:EntityBase<int>
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
