using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class PerformancerequirementFullDto : Performancerequirement
    {

    }


    public class PerformancerequirementUniqPropsDto0 : Mapper<Performancerequirement>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class PerformancerequirementAddDto : Mapper<Performancerequirement>
    {
        public string? Name { get; set; }
        public ushort? LapsCount { get; set; }
        public uint? TotalTimeMs { get; set; }
        public uint? BestLapMs { get; set; }
        public uint? StintAverageMs { get; set; }
        public uint? BestSector1Ms { get; set; }
        public uint? BestSector2Ms { get; set; }
        public uint? BestSector3Ms { get; set; }
        public ushort? ValidLapsCount { get; set; }
        public ushort? ValidStintsCount { get; set; }
    }


    public class PerformancerequirementUpdateDto : PerformancerequirementAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class PerformancerequirementFilterDto : PerformancerequirementAddDto
    {
        public int? Id { get; set; }
    }


    public class PerformancerequirementFilterDtos
    {
        public PerformancerequirementFilterDto Filter { get; set; } = new();
        public PerformancerequirementFilterDto FilterMin { get; set; } = new();
        public PerformancerequirementFilterDto FilterMax { get; set; } = new();
    }
}
