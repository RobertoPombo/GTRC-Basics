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
        public Byte? MinEntriesPerTeam { get; set; }
        public Byte? MaxEntriesPerTeam { get; set; }
        public bool? ForceDriverFromOrganization { get; set; }
        public bool? AllowDriverLineupPerEvent { get; set; }
        public DateTime? DateStartRegistration { get; set; }
        public DateTime? DateEndRegistration { get; set; }
        public Byte? MaxGridSlots { get; set; }
        public Byte? MaxNoShows { get; set; }
        public Byte? MaxSignOuts { get; set; }
        public Byte? CarRegristrationLimit { get; set; }
        public DateTime? DateStartCarRegristrationLimit { get; set; }
        public bool? GroupCarRegristrationLimits { get; set; }
        public ushort? DaysIgnoreCarRegristrationLimit { get; set; }
        public Byte? CarChangeLimit { get; set; }
        public DateTime? DateStartCarChangeLimit { get; set; }
        public int? BopId { get; set; }
        public DateTime? DateBoPFreeze { get; set; }
        public bool? BopLatestModelOnly { get; set; }
        public Byte? CarLimitBallast { get; set; }
        public Byte? GainBallast { get; set; }
        public Byte? CarLimitRestrictor { get; set; }
        public Byte? GainRestrictor { get; set; }
        public ulong? DiscordDriverRoleId { get; set; }
        public ulong? DiscordRegistrationChannelId { get; set; }
        public ulong? DiscordTrackReportChannelId { get; set; }
        public string? ShortDescription { get; set; }
        public string? GeneralDescription { get; set; }
        public string? SpecificDescription { get; set; }
        public FormationLapType? FormationLapType { get; set; }
    }


    public class SeasonUpdateDto : SeasonAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SeasonFilterDto : SeasonAddDto
    {
        public int? Id { get; set; }
        public string? Series { get; set; }
        public string? Bop { get; set; }
    }


    public class SeasonFilterDtos
    {
        public SeasonFilterDto Filter { get; set; } = new();
        public SeasonFilterDto FilterMin { get; set; } = new();
        public SeasonFilterDto FilterMax { get; set; } = new();
    }
}
