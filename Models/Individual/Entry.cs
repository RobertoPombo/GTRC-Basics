using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Entry : IBaseModel
    {
        public static readonly ushort DefaultRaceNumber = 2;
        public static readonly ushort MinRaceNumber = 1;
        public static readonly ushort MaxRaceNumber = 999;

        public override string ToString() { return "#" + RaceNumber.ToString() + " " + Team.ToString() + " - " + Season.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Season))] public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = new();
        public ushort RaceNumber { get; set; } = DefaultRaceNumber;
        [ForeignKey(nameof(Team))] public int TeamId { get; set; }
        public virtual Team Team { get; set; } = new();
        [ForeignKey(nameof(Car))] public int CarId { get; set; }
        public virtual Car Car { get; set; } = new();
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
        public DateTime SignOutDate { get; set; } = GlobalValues.DateTimeMaxValue;
        public short BallastKg { get; set; }
        public short Restrictor { get; set; }
        public bool IsPointScorer { get; set; } = true;
        public bool IsPermanent { get; set; } = true;
    }
}
