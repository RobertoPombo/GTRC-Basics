using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Season : IBaseModel
    {
        public static readonly string DefaultName = nameof(Season) + " #1";
        public static readonly Byte MinMinDriversPerEntry = 1;
        public static readonly Byte MinMinEntriesPerTeam = 1;

        public override string ToString() { return Id.ToString() + ". " + Name + " (" + Series.Name + ")"; }

        public int Id { get; set; }
        [ForeignKey(nameof(Series))] public int SeriesId { get; set; }
        public virtual Series Series { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public Byte MinDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public Byte MaxDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public Byte MinEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public Byte MaxEntriesPerTeam { get; set; } = MinMinEntriesPerTeam;
        public bool ForceDriverFromOrganization { get; set; } = true;
        public bool AllowDriverLineupPerEvent { get; set; } = false;
        public DateTime DateStartRegistration { get; set; } = DateTime.UtcNow;
        public DateTime DateEndRegistration { get; set; } = DateTime.UtcNow;
        public Byte MaxGridSlots { get; set; } = Byte.MinValue;
        public Byte MaxNoShows { get; set; } = Byte.MinValue;
        public Byte MaxSignOuts { get; set; } = Byte.MinValue;
        public Byte CarRegristrationLimit { get; set; } = Byte.MinValue;
        public DateTime DateStartCarRegristrationLimit { get; set; } = DateTime.UtcNow;
        public bool GroupCarRegristrationLimits { get; set; } = false;
        public ushort DaysIgnoreCarRegristrationLimit { get; set; } = ushort.MinValue;
        public Byte CarChangeLimit { get; set; } = Byte.MinValue;
        public DateTime DateStartCarChangeLimit { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Bop))] public int BopId { get; set; }
        public virtual Bop Bop { get; set; } = new();
        public DateTime DateBoPFreeze { get; set; } = DateTime.UtcNow;
        public bool BopLatestModelOnly { get; set; } = false;
        public Byte CarLimitBallast { get; set; } = Byte.MinValue;
        public Byte GainBallast { get; set; } = Byte.MinValue;
        public Byte CarLimitRestrictor { get; set; } = Byte.MinValue;
        public Byte GainRestrictor { get; set; } = Byte.MinValue;
        public ulong DiscordDriverRoleId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordRegistrationChannelId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordTrackReportChannelId { get; set; } = GlobalValues.NoDiscordId;
        public string ShortDescription { get; set; } = string.Empty;
        public string GeneralDescription { get; set; } = string.Empty;
        public string SpecificDescription { get; set; } = string.Empty;
        public FormationLapType FormationLapType { get; set; } = FormationLapType.Manual;
    }
}
