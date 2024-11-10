using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Performancerequirement : IBaseModel
    {
        public static readonly string DefaultName = "Performance Requirement #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
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
