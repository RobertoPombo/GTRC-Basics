using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Track : IBaseModel
    {
        public static readonly string DefaultName = nameof(Track) + " #1";
        public static readonly string DefaultAccTrackId = nameof(AccTrackId).ToLower();
        public static readonly ushort DefaultAccTimePenDtS = 30;

        public override string ToString() { return Id.ToString() + ". " + Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public string AccTrackId { get; set; } = DefaultAccTrackId;
        public ushort PitBoxesCount { get; set; } = ushort.MinValue;
        public ushort ServerSlotsCount { get; set; } = ushort.MinValue;
        public ushort AccTimePenDtS { get; set; } = DefaultAccTimePenDtS;
        public string NameGtrc { get; set; } = string.Empty;
    }
}
