using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeasonFullDto : Season
    {

    }


    public class SeasonUniqPropsDto0 : Mapper<Season>
    {
        [Required] public string Name { get; set; } = Season.DefaultName;
    }


    public class SeasonAddDto : Mapper<Season>
    {
        public string? Name { get; set; }
    }


    public class SeasonUpdateDto : SeasonAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeasonFilterDto : SeasonAddDto
    {
        public int? Id { get; set; }
    }


    public class SeasonFilterDtos
    {
        public SeasonFilterDto Filter { get; set; } = new();
        public SeasonFilterDto FilterMin { get; set; } = new();
        public SeasonFilterDto FilterMax { get; set; } = new();
    }
}
