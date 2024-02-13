using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class EntryUserEvent : IBaseModel
    {
        public static readonly string DefaultName3Digits = "   ";

        public override string ToString() { return Entry.ToString() + " | " + User.ToString() + " | " + Event.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Entry))] public int EntryId { get; set; }
        public virtual Entry Entry { get; set; } = new();
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        public string Name3Digits { get; set; } = DefaultName3Digits;
    }
}
