using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeasonFullDto : Season
    {

    }


    public class SeasonUniqPropsDto0 : Mapper<Season>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class SeasonAddDto : Mapper<Season>
    {
        public string? Name { get; set; }
        public int? SeriesId { get; set; }
        public Byte? MinDriversPerEntry { get; set; }
        public Byte? MaxDriversPerEntry { get; set; }
        public Byte? GridSlotsLimit { get; set; }
        public Byte? CarLimitBallast { get; set; }
        public Byte? GainBallast { get; set; }
        public Byte? CarLimitRestrictor { get; set; }
        public Byte? GainRestrictor { get; set; }
        public Byte? CarLimitRegisterLimit { get; set; }
        public DateTime? DateRegisterLimit { get; set; }
        public DateTime? DateBoPFreeze { get; set; }
        public Byte? NoShowLimit { get; set; }
        public Byte? SignOutLimit { get; set; }
        public Byte? CarChangeLimit { get; set; }
        public DateTime? DateCarChangeLimit { get; set; }
        public bool? GroupCarLimits { get; set; }
        public bool? BopLatestModelOnly { get; set; }
        public ushort? DaysIgnoreCarLimits { get; set; }
        public FormationLapType? FormationLapType { get; set; }
        public ulong? DiscordRoleId { get; set; }
        public ulong? DiscordChannelId { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
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
