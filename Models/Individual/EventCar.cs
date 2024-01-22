using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class EventCar : IBaseModel
    {
        public override string ToString() { return Event.ToString() + " | " + Car.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public virtual Car Car { get; set; } = new();
        public short BallastKg { get; set; }
        public short Restrictor { get; set; }
        public byte Count { get; set; }
        public byte CountBop { get; set; }
    }
}
