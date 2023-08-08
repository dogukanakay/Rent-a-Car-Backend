using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
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




     // Filters Tools
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? GearId { get; set; }
        public int? FuelId { get; set; }
        public int? ColorId { get; set; }


    }
}
