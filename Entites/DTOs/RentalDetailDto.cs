using Core.Entities.Abstract;
using Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:RentalDetailFilter,IDto
    {
        public int RentId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string GearTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ReturnDateActual { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
