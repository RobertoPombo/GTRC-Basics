using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class SeriesDiscordchanneltype : IBaseModel
    {
        public override string ToString() { return Series.Name + " - " + DiscordChannelType.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Series))] public int SeriesId { get; set; }
        public virtual Series Series { get; set; } = new();
        public DiscordChannelType DiscordChannelType { get; set; } = DiscordChannelType.Log;
        public ulong DiscordId { get; set; } = GlobalValues.NoDiscordId;
    }
}
