using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Stintanalysismethod : IBaseModel
    {
        public static readonly string DefaultName = "Stint Analysis Method #1";
        public static readonly ushort MinMaxTimeDeltaPercent = 100;

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public bool UseResultsFromSimulation { get; set; } = true;
        public ResultsCombinationType ResultsCombinationType { get; set; } = ResultsCombinationType.Best;
        public ushort LapRange { get; set; } = ushort.MaxValue;
        public ushort MaxLapsInvalid { get; set; } = ushort.MaxValue;
        public ushort MaxTimeDeltaPercent { get; set; } = ushort.MaxValue;
        public ushort MinLapsValidConsecutive { get; set; } = ushort.MinValue;
        public ushort MinLapsCount { get; set; } = ushort.MinValue;
        public ushort MaxLapsCount { get; set; } = ushort.MaxValue;
        public bool ForceLapsConsecutive { get; set; } = false;
        public bool CombineSessions { get; set; } = false;
        public ushort LapsCountCombined { get; set; } = ushort.MinValue;
    }
}
