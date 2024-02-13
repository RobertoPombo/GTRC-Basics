using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class PointssystemFullDto : Pointssystem
    {

    }


    public class PointssystemUniqPropsDto0 : Mapper<Pointssystem>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class PointssystemAddDto : Mapper<Pointssystem>
    {
        public string? Name { get; set; }
        public byte? MinPercentageOfP1 { get; set; }
        public ushort? MaxPercentageOfP1 { get; set; }
        public ushort? MinLaps { get; set; }
        public ushort? MaxLapsToP1 { get; set; }
    }


    public class PointssystemUpdateDto : PointssystemAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class PointssystemFilterDto : PointssystemAddDto
    {
        public int? Id { get; set; }
    }


    public class PointssystemFilterDtos
    {
        public PointssystemFilterDto Filter { get; set; } = new();
        public PointssystemFilterDto FilterMin { get; set; } = new();
        public PointssystemFilterDto FilterMax { get; set; } = new();
    }
}
