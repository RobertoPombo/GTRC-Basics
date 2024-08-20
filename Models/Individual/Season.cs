using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Season : IBaseModel
    {
        public static readonly string DefaultName = nameof(Season) + " #1";
        public static readonly byte MinMinDriversPerEntryEvent = 1;
        public static readonly byte MinMinEntriesPerTeam = 1;

        public override string ToString() { return Name + " - " + Series.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Series))] public int SeriesId { get; set; }
        public virtual Series Series { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public byte MinDriversPerEntryEvent { get; set; } = MinMinDriversPerEntryEvent;
        public byte MaxDriversPerEntryEvent { get; set; } = MinMinDriversPerEntryEvent;
        public byte MinEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public byte MaxEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public bool IsAllowedEntriesShareDriverSameEvent { get; set; } = false;
        public bool IsAllowedEntriesShareDriver { get; set; } = false;
        public bool IsAllowedDriverLineupPerEvent { get; set; } = false;
        public bool ForceDriverFromOrganization { get; set; } = true;
        public DateTime DateStartRegistration { get; set; } = GlobalValues.DateTimeMinValue;
        public DateTime DateEndRegistration { get; set; } = GlobalValues.DateTimeMaxValue;
        public byte MaxNoShows { get; set; } = byte.MinValue;
        public byte MaxSignOuts { get; set; } = byte.MinValue;
        public byte CarRegistrationLimit { get; set; } = byte.MinValue;
        public DateTime DateStartCarRegistrationLimit { get; set; } = GlobalValues.DateTimeMaxValue;
        public bool GroupCarRegistrationLimits { get; set; } = false;
        public ushort DaysIgnoreCarRegistrationLimit { get; set; } = ushort.MinValue;
        public byte CarChangeLimit { get; set; } = byte.MinValue;
        public DateTime DateStartCarChangeLimit { get; set; } = GlobalValues.DateTimeMaxValue;
        [ForeignKey(nameof(Bop))] public int BopId { get; set; }
        public virtual Bop Bop { get; set; } = new();
        public DateTime DateBoPFreeze { get; set; } = GlobalValues.DateTimeMaxValue;
        public bool BopLatestModelOnly { get; set; } = false;
        public byte CarLimitBallast { get; set; } = byte.MinValue;
        public byte GainBallast { get; set; } = byte.MinValue;
        public byte CarLimitRestrictor { get; set; } = byte.MinValue;
        public byte GainRestrictor { get; set; } = byte.MinValue;
        public DateTime DateEndAutoGenerateRaceNumbers { get; set; } = GlobalValues.DateTimeMaxValue;
        public DateTime DateEndChangeTeam { get; set; } = GlobalValues.DateTimeMaxValue;
        public string ShortDescription { get; set; } = string.Empty;
        public string GeneralDescription { get; set; } = string.Empty;
        public string SpecificDescription { get; set; } = string.Empty;
        public FormationLapType FormationLapType { get; set; } = FormationLapType.Manual;
    }
}
