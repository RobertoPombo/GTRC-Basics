using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Track : BaseModel
    {
        public static readonly string DefaultAccTrackID = "TrackID";
        static Track() { UniqProps = [[typeof(Track).GetProperty(nameof(AccTrackId))!]]; }

        public string AccTrackId { get; set; } = DefaultAccTrackID;
        public string Name { get; set; } = "";
        public int PitBoxesCount { get; set; } = 0;
        public int ServerSlotsCount { get; set; } = 0;
        public int AccTimePenDT { get; set; } = 30;
        public string NameGtrc { get; set; } = "";
    }
}
