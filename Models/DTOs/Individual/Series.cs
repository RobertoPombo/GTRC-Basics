using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeriesFullDto : Series
    {

    }


    public class SeriesUniqPropsDto0 : Mapper<Series>
    {
        [Required] public int SimId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class SeriesUniqPropsDto1 : Mapper<Series>
    {
        [Required] public ulong DiscordDriverRoleId { get; set; } = GlobalValues.NoDiscordId;
    }


    public class SeriesAddDto : Mapper<Series>
    {
        public int? SimId { get; set; }
        public string? Name { get; set; }
        public ulong? DiscordDriverRoleId { get; set; }
    }


    public class SeriesUpdateDto : SeriesAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeriesFilterDto : SeriesAddDto
    {
        public int? Id { get; set; }
        public string? Sim { get; set; }
    }


    public class SeriesFilterDtos
    {
        public SeriesFilterDto Filter { get; set; } = new();
        public SeriesFilterDto FilterMin { get; set; } = new();
        public SeriesFilterDto FilterMax { get; set; } = new();
    }
}
