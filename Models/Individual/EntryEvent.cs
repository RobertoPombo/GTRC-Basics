using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class EntryEvent : IBaseModel
    {
        public override string ToString() { return Entry.ToString() + " | " + Event.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Entry))] public int EntryId { get; set; }
        public virtual Entry Entry { get; set; } = new();
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        public DateTime SignInDate { get; set; } = GlobalValues.DateTimeMaxValue;
        public bool IsOnEntrylist { get; set; } = false;
        public bool DidAttend { get; set; } = false;
        public short BallastKg { get; set; }
        public short Restrictor { get; set; }
        public bool IsPointScorer { get; set; } = true;
        public ushort Priority { get; set; } = ushort.MaxValue;
    }
}
