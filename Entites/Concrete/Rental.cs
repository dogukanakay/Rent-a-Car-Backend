using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entites.Concrete;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental:EntityBase<int>
    {
       
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropoffLocationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ReturnDateActual { get; set; }
        public double TotalPrice { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual RentalLocation RentalLocation { get; set; }

    }
}
