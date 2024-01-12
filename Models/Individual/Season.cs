using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Season : IBaseModel
    {
        public static readonly string DefaultName = nameof(Season) + " #1";
        public static readonly Byte MinMinDriversPerEntry = 1;

        public override string ToString() { return Id.ToString() + ". " + Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        [ForeignKey(nameof(Series))] public int SeriesId { get; set; }
        public virtual Series Series { get; set; } = new();
        public Byte MinDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public Byte MaxDriversPerEntry { get; set; } = MinMinDriversPerEntry;
        public Byte GridSlotsLimit { get; set; } = Byte.MinValue;
        public Byte CarLimitBallast { get; set; } = Byte.MinValue;
        public Byte GainBallast { get; set; } = Byte.MinValue;
        public Byte CarLimitRestrictor { get; set; } = Byte.MinValue;
        public Byte GainRestrictor { get; set; } = Byte.MinValue;
        public Byte CarLimitRegisterLimit { get; set; } = Byte.MinValue;
        public DateTime DateRegisterLimit { get; set; } = DateTime.UtcNow;
        public DateTime DateBoPFreeze { get; set; } = DateTime.UtcNow;
        public Byte NoShowLimit { get; set; } = Byte.MinValue;
        public Byte SignOutLimit { get; set; } = Byte.MinValue;
        public Byte CarChangeLimit { get; set; } = Byte.MinValue;
        public DateTime DateCarChangeLimit { get; set; } = DateTime.UtcNow;
        public bool GroupCarLimits { get; set; } = false;
        public bool BopLatestModelOnly { get; set; } = false;
        public ushort DaysIgnoreCarLimits { get; set; } = ushort.MinValue;
        public ulong DiscordRoleId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordChannelId { get; set; } = GlobalValues.NoDiscordId;
        public FormationLapType FormationLapType { get; set; } = FormationLapType.Manual;
        public string ShortDescription { get; set; } = string.Empty;
        public string GeneralDescription { get; set; } = string.Empty;
        public string SpecificDescription { get; set; } = string.Empty;
    }
}
