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
    public class Customer:Entity<int>
    {

        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int FindexScore { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentCard> PaymentCards { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

    }
}
