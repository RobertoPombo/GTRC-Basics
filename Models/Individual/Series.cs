using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Series : IBaseModel
    {
        public static readonly string DefaultName = nameof(Series) + " #1";

        public override string ToString() { return Name + " - " + Sim.ShortName; }

        public int Id { get; set; }
        [ForeignKey(nameof(Sim))] public int SimId { get; set; }
        public virtual Sim Sim { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public ulong DiscordDriverRoleId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordLogChannelId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordRegistrationChannelId { get; set; } = GlobalValues.NoDiscordId;
        public ulong DiscordTrackReportChannelId { get; set; } = GlobalValues.NoDiscordId;
    }
}
