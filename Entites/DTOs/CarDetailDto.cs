using Core.Entities.Abstract;
using Entities.Filters;

namespace Entities.DTOs
{
    public class CarDetailDto:CarDetailFilter ,IDto
    {
        public int CarId { get; set; }
        public string LocationName { get; set; }
        public string ClassName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string GearTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int FindexScore { get; set; }
        public string Description { get; set; }


    }
}
