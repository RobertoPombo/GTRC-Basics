using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class BopTrackCar : IBaseModel
    {
        public override string ToString() { return Bop.ToString() + " - " + Track.Name + " - " + Car.Name; }

        public int Id { get; set; }
        [ForeignKey(nameof(Bop))] public int BopId { get; set; }
        public virtual Bop Bop { get; set; } = new();
        [ForeignKey(nameof(Track))] public int TrackId { get; set; }
        public virtual Track Track { get; set; } = new();
        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public virtual Car Car { get; set; } = new();
        public short BallastKg { get; set; }
        public short Restrictor { get; set; }
    }
}
