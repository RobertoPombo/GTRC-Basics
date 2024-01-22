using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class EventCarclass : IBaseModel
    {
        public override string ToString() { return Event.ToString() + " | " + Carclass.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        [ForeignKey(nameof(Carclass))] public int CarclassId { get; set; }
        public virtual Carclass Carclass { get; set; } = new();
    }
}
