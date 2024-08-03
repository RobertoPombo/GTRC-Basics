using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Leaderboardline : IBaseModel
    {
        public override string ToString() { return User.ToString() + " - " + Entry.ToString() + " - " + Car.ToString() + " - " + Session.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Session))] public int SessionId { get; set; }
        public virtual Session Session { get; set; } = new();
        [ForeignKey(nameof(Entry))] public int EntryId { get; set; }
        public virtual Entry Entry { get; set; } = new();
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public virtual Car Car { get; set; } = new();
        public ushort LapsCount { get; set; } = ushort.MinValue;
        public uint TotalTimeMs { get; set; } = uint.MaxValue;
        public uint BestLapMs { get; set; } = uint.MaxValue;
        public uint StintAverageMs { get; set; } = uint.MaxValue;
        public uint BestSector1Ms { get; set; } = uint.MaxValue;
        public uint BestSector2Ms { get; set; } = uint.MaxValue;
        public uint BestSector3Ms { get; set; } = uint.MaxValue;
        public ushort ValidLapsCount { get; set; } = ushort.MinValue;
        public ushort ValidStintsCount { get; set; } = ushort.MinValue;
    }
}
