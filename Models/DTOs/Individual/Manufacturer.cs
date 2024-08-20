using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class ManufacturerFullDto : Manufacturer
    {
        public string Logo
        {
            get { return GetLogo(this); }
            set { }
        }

        public static string GetLogo(Manufacturer obj)
        {
            return GlobalValues.ManufacturerLogosDirectory + obj.Name + ".png";
        }
    }


    public class ManufacturerUniqPropsDto0 : Mapper<Manufacturer>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class ManufacturerAddDto : Mapper<Manufacturer>
    {
        public string? Name { get; set; }
    }


    public class ManufacturerUpdateDto : ManufacturerAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class ManufacturerFilterDto : ManufacturerAddDto
    {
        public int? Id { get; set; }
    }


    public class ManufacturerFilterDtos
    {
        public ManufacturerFilterDto Filter { get; set; } = new();
        public ManufacturerFilterDto FilterMin { get; set; } = new();
        public ManufacturerFilterDto FilterMax { get; set; } = new();
    }
}
