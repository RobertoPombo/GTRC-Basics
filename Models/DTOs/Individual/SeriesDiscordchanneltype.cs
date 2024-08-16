using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeriesDiscordchanneltypeFullDto : SeriesDiscordchanneltype
    {

    }


    public class SeriesDiscordchanneltypeUniqPropsDto0 : Mapper<SeriesDiscordchanneltype>
    {
        [Required] public int SeriesId { get; set; }
        [Required] public DiscordChannelType DiscordChannelType { get; set; } = DiscordChannelType.Log;
    }


    public class SeriesDiscordchanneltypeUniqPropsDto1 : Mapper<SeriesDiscordchanneltype>
    {
        [Required] public ulong DiscordId { get; set; } = GlobalValues.NoDiscordId;
    }


    public class SeriesDiscordchanneltypeAddDto : Mapper<SeriesDiscordchanneltype>
    {
        public int? SeriesId { get; set; }
        public DiscordChannelType? DiscordChannelType { get; set; }
        public ulong? DiscordId { get; set; }
    }


    public class SeriesDiscordchanneltypeUpdateDto : SeriesDiscordchanneltypeAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeriesDiscordchanneltypeFilterDto : SeriesDiscordchanneltypeAddDto
    {
        public int? Id { get; set; }
        public string? Series { get; set; }
    }


    public class SeriesDiscordchanneltypeFilterDtos
    {
        public SeriesDiscordchanneltypeFilterDto Filter { get; set; } = new();
        public SeriesDiscordchanneltypeFilterDto FilterMin { get; set; } = new();
        public SeriesDiscordchanneltypeFilterDto FilterMax { get; set; } = new();
    }
}
