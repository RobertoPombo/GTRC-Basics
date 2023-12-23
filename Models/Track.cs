using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Track : IBaseModel
    {
        public static readonly string DefaultAccTrackID = "TrackID";

        public int Id { get; set; }
        public string AccTrackId { get; set; } = DefaultAccTrackID;
        public string Name { get; set; } = "";
        public int PitBoxesCount { get; set; } = 0;
        public int ServerSlotsCount { get; set; } = 0;
        public int AccTimePenDT { get; set; } = 30;
        public string NameGtrc { get; set; } = "";
    }
}
