using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class EntryDatetime : IBaseModel
    {
        public override string ToString() { return Entry.ToString() + " | " + Date.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Entry))] public int EntryId { get; set; }
        public virtual Entry Entry { get; set; } = new();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public virtual Car Car { get; set; } = new();
    }
}
