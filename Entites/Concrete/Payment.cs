using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        [Key]
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int RentId { get; set; }
        public double AmountPaid { get; set; }
    }
}
