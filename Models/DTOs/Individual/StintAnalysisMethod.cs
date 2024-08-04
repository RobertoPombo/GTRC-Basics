using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class StintAnalysisMethodFullDto : StintAnalysisMethod
    {

    }


    public class StintAnalysisMethodUniqPropsDto0 : Mapper<StintAnalysisMethod>
    {
        [Required] public string Name { get; set; } = StintAnalysisMethod.DefaultName;
    }


    public class StintAnalysisMethodAddDto : Mapper<StintAnalysisMethod>
    {
        public string? Name { get; set; }
        public bool? UseResultsFromSimulation { get; set; }
        public ushort? LapRange { get; set; }
        public ushort? MaxInvalidLapsInRange { get; set; }
        public uint? MaxTimeDeltaInRangeMs { get; set; }
        public ushort? ConsecutiveValidLapsMin { get; set; }
        public ushort? MinLapsCount { get; set; }
        public ushort? MaxLapsCount { get; set; }
        public bool? ForceLapsCountConsecutive { get; set; }
        public bool? CombineSessions { get; set; }
        public ushort? LapsCountCombined { get; set; }
    }


    public class StintAnalysisMethodUpdateDto : StintAnalysisMethodAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class StintAnalysisMethodFilterDto : StintAnalysisMethodAddDto
    {
        public int? Id { get; set; }
    }


    public class StintAnalysisMethodFilterDtos
    {
        public StintAnalysisMethodFilterDto Filter { get; set; } = new();
        public StintAnalysisMethodFilterDto FilterMin { get; set; } = new();
        public StintAnalysisMethodFilterDto FilterMax { get; set; } = new();
    }
}
