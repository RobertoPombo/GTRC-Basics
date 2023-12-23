using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Car : IBaseModel
    {
        public int Id { get; set; }
        public int AccCarId { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string Model { get; set; } = "";
        public CarClass Class { get; set; } = CarClass.General;
        public int Year { get; set; } = DateTime.Now.Year;
        public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int WidthMm { get; set; } = 2000;
        public int LengthMm { get; set; } = 5000;
        public string NameGtrc { get; set; } = "";
    }
}
