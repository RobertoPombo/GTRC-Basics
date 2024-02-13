using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Pointssystem : IBaseModel
    {
        public static readonly string DefaultName = nameof(Pointssystem) + " #1";
        public static readonly byte MaxMinPercentageOfP1 = 100;
        public static readonly byte MinMaxPercentageOfP1 = 100;

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public byte MinPercentageOfP1 { get; set; } = byte.MinValue;
        public ushort MaxPercentageOfP1 { get; set; } = ushort.MaxValue;
        public ushort MinLaps { get; set; } = ushort.MinValue;
        public ushort MaxLapsToP1 { get; set; } = ushort.MaxValue;
    }
}
