using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class StintanalysismethodFullDto : Stintanalysismethod
    {

    }


    public class StintanalysismethodUniqPropsDto0 : Mapper<Stintanalysismethod>
    {
        [Required] public string Name { get; set; } = Stintanalysismethod.DefaultName;
    }


    public class StintanalysismethodAddDto : Mapper<Stintanalysismethod>
    {
        public string? Name { get; set; }
        public bool? UseResultsFromSimulation { get; set; }
        public ResultsCombinationType? ResultsCombinationType { get; set; }
        public ushort? LapRange { get; set; }
        public ushort? MaxLapsInvalid { get; set; }
        public ushort? MaxTimeDeltaPercent { get; set; }
        public ushort? MinLapsValidConsecutive { get; set; }
        public ushort? MinLapsCount { get; set; }
        public ushort? MaxLapsCount { get; set; }
        public bool? ForceLapsConsecutive { get; set; }
        public bool? CombineSessions { get; set; }
        public ushort? LapsCountCombined { get; set; }
    }


    public class StintanalysismethodUpdateDto : StintanalysismethodAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class StintanalysismethodFilterDto : StintanalysismethodAddDto
    {
        public int? Id { get; set; }
    }


    public class StintanalysismethodFilterDtos
    {
        public StintanalysismethodFilterDto Filter { get; set; } = new();
        public StintanalysismethodFilterDto FilterMin { get; set; } = new();
        public StintanalysismethodFilterDto FilterMax { get; set; } = new();
    }
}
