using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SimFullDto : Sim
    {

    }


    public class SimUniqPropsDto0 : Mapper<Sim>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class SimAddDto : Mapper<Sim>
    {
        public string? Name { get; set; }
    }


    public class SimUpdateDto : SimAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SimFilterDto : SimAddDto
    {
        public int? Id { get; set; }
    }


    public class SimFilterDtos
    {
        public SimFilterDto Filter { get; set; } = new();
        public SimFilterDto FilterMin { get; set; } = new();
        public SimFilterDto FilterMax { get; set; } = new();
    }
}
