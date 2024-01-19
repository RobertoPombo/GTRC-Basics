using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeriesFullDto : Series
    {

    }


    public class SeriesUniqPropsDto0 : Mapper<Series>
    {
        [Required] public int CommunityId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class SeriesAddDto : Mapper<Series>
    {
        public int? CommunityId { get; set; }
        public string? Name { get; set; }
        public int? SimId { get; set; }
        public ulong? DiscordRegistrationChannelId { get; set; }
        public ulong? DiscordLogChannelId { get; set; }
    }


    public class SeriesUpdateDto : SeriesAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeriesFilterDto : SeriesAddDto
    {
        public int? Id { get; set; }
        public string? Community { get; set; }
        public string? Sim { get; set; }
    }


    public class SeriesFilterDtos
    {
        public SeriesFilterDto Filter { get; set; } = new();
        public SeriesFilterDto FilterMin { get; set; } = new();
        public SeriesFilterDto FilterMax { get; set; } = new();
    }
}
