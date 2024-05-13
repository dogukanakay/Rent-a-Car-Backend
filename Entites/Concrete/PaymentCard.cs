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
    public class PaymentCard : Entity<int>
    {
       
        public int CustomerId { get; set; }
        public string CardNumbers { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
        public int Cvv { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
