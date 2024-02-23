using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class CarFullDto : Car
    {

    }


    public class CarUniqPropsDto0 : Mapper<Car>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class CarUniqPropsDto1 : Mapper<Car>
    {
        [Required] public uint AccCarId { get; set; } = uint.MinValue;
    }


    public class CarAddDto : Mapper<Car>
    {
        public string? Name { get; set; }
        public uint? AccCarId { get; set; }
        public int? ManufacturerId { get; set; }
        public string? Model { get; set; }
        public int? CarclassId { get; set; }
        public ushort? Year { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public ushort? WidthMm { get; set; }
        public ushort? LengthMm { get; set; }
        public string? NameLfm { get; set; }
        public string? NameGoogleSheets { get; set; }
    }


    public class CarUpdateDto : CarAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class CarFilterDto : CarAddDto
    {
        public int? Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Carclass { get; set; }
    }


    public class CarFilterDtos
    {
        public CarFilterDto Filter { get; set; } = new();
        public CarFilterDto FilterMin { get; set; } = new();
        public CarFilterDto FilterMax { get; set; } = new();
    }
}
