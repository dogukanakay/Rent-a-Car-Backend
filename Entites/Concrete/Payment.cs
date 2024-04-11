using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : EntityBase<int>
    {
        
        public int CustomerId { get; set; }
        public int? RentId { get; set; }
        public double AmountPaid { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
