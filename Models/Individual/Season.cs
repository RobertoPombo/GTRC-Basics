using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Season : IBaseModel
    {
        public static readonly string DefaultName = nameof(Season) + " #1";
        public static readonly byte MinMinDriversPerEntry = 1;
        public static readonly byte MinMinEntriesPerTeam = 1;

        public override string ToString() { return Name + " - " + Series.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Series))] public int SeriesId { get; set; }
        public virtual Series Series { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public byte MinDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public byte MaxDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public byte MinEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public byte MaxEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public bool ForceDriverFromOrganization { get; set; } = true;
        public bool AllowDriverLineupPerEvent { get; set; } = false;
        public DateTime DateStartRegistration { get; set; } = DateTime.UtcNow;
        public DateTime DateEndRegistration { get; set; } = DateTime.UtcNow;
        public byte MaxNoShows { get; set; } = byte.MinValue;
        public byte MaxSignOuts { get; set; } = byte.MinValue;
        public byte CarRegistrationLimit { get; set; } = byte.MinValue;
        public DateTime DateStartCarRegistrationLimit { get; set; } = DateTime.UtcNow;
        public bool GroupCarRegistrationLimits { get; set; } = false;
        public ushort DaysIgnoreCarRegistrationLimit { get; set; } = ushort.MinValue;
        public byte CarChangeLimit { get; set; } = byte.MinValue;
        public DateTime DateStartCarChangeLimit { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Bop))] public int BopId { get; set; }
        public virtual Bop Bop { get; set; } = new();
        public DateTime DateBoPFreeze { get; set; } = DateTime.UtcNow;
        public bool BopLatestModelOnly { get; set; } = false;
        public byte CarLimitBallast { get; set; } = byte.MinValue;
        public byte GainBallast { get; set; } = byte.MinValue;
        public byte CarLimitRestrictor { get; set; } = byte.MinValue;
        public byte GainRestrictor { get; set; } = byte.MinValue;
        public ulong DiscordDriverRoleId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordRegistrationChannelId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordTrackReportChannelId { get; set; } = GlobalValues.NoDiscordId;
        public string ShortDescription { get; set; } = string.Empty;
        public string GeneralDescription { get; set; } = string.Empty;
        public string SpecificDescription { get; set; } = string.Empty;
        public FormationLapType FormationLapType { get; set; } = FormationLapType.Manual;
    }
}
