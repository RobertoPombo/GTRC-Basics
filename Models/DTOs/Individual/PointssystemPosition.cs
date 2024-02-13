using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class PointssystemPositionFullDto : PointssystemPosition
    {

    }


    public class PointssystemPositionUniqPropsDto0 : Mapper<PointssystemPosition>
    {
        [Required] public int PointssystemId { get; set; }
        [Required] public byte Position { get; set; }
    }


    public class PointssystemPositionAddDto : Mapper<PointssystemPosition>
    {
        public int? PointssystemId { get; set; }
        public byte? Position { get; set; }
        public short? Points { get; set; }
    }


    public class PointssystemPositionUpdateDto : PointssystemPositionAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class PointssystemPositionFilterDto : PointssystemPositionAddDto
    {
        public int? Id { get; set; }
        public string? Pointssystem { get; set; }
    }


    public class PointssystemPositionFilterDtos
    {
        public PointssystemPositionFilterDto Filter { get; set; } = new();
        public PointssystemPositionFilterDto FilterMin { get; set; } = new();
        public PointssystemPositionFilterDto FilterMax { get; set; } = new();
    }
}
