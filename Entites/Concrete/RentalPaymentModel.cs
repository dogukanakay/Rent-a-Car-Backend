using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RentalPaymentModel:IEntity
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
