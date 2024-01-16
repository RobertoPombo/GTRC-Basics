using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeasonCarclassFullDto : SeasonCarclass
    {

    }


    public class SeasonCarclassUniqPropsDto0 : Mapper<SeasonCarclass>
    {
        [Required] public int SeasonId { get; set; }
        [Required] public int CarclassId { get; set; }
    }


    public class SeasonCarclassAddDto : Mapper<SeasonCarclass>
    {
        public int? SeasonId { get; set; }
        public int? CarclassId { get; set; }
    }


    public class SeasonCarclassUpdateDto : SeasonCarclassAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeasonCarclassFilterDto : SeasonCarclassAddDto
    {
        public int? Id { get; set; }
        public string? Season { get; set; }
        public string? Carclass { get; set; }
    }


    public class SeasonCarclassFilterDtos
    {
        public SeasonCarclassFilterDto Filter { get; set; } = new();
        public SeasonCarclassFilterDto FilterMin { get; set; } = new();
        public SeasonCarclassFilterDto FilterMax { get; set; } = new();
    }
}
