using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SeasonFullDto : Season
    {

    }


    public class SeasonUniqPropsDto0 : Mapper<Season>
    {
        [Required] public int SeriesId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class SeasonAddDto : Mapper<Season>
    {
        public int? SeriesId { get; set; }
        public string? Name { get; set; }
        public byte? MinDriversPerEntryEvent { get; set; }
        public byte? MaxDriversPerEntryEvent { get; set; }
        public byte? MinEntriesPerTeam { get; set; }
        public byte? MaxEntriesPerTeam { get; set; }
        public bool? AllowEntriesShareDriverSameEvent { get; set; }
        public bool? AllowEntriesShareDriver { get; set; }
        public bool? AllowDriverLineupPerEvent { get; set; }
        public bool? ForceDriverFromOrganization { get; set; }
        public DateTime? DateStartRegistration { get; set; }
        public DateTime? DateEndRegistration { get; set; }
        public byte? MaxNoShows { get; set; }
        public byte? MaxSignOuts { get; set; }
        public byte? CarRegistrationLimit { get; set; }
        public DateTime? DateStartCarRegistrationLimit { get; set; }
        public bool? GroupCarRegistrationLimits { get; set; }
        public ushort? DaysIgnoreCarRegistrationLimit { get; set; }
        public byte? CarChangeLimit { get; set; }
        public DateTime? DateStartCarChangeLimit { get; set; }
        public int? BopId { get; set; }
        public DateTime? DateBoPFreeze { get; set; }
        public bool? BopLatestModelOnly { get; set; }
        public byte? CarLimitBallast { get; set; }
        public byte? GainBallast { get; set; }
        public byte? CarLimitRestrictor { get; set; }
        public byte? GainRestrictor { get; set; }
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
