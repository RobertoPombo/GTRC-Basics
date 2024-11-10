using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class PrequalifyingFullDto : Prequalifying
    {

    }


    public class PrequalifyingUniqPropsDto0 : Mapper<Prequalifying>
    {
        [Required] public int EventId { get; set; }
        public SessionPurpose? SessionPurpose { get; set; }
        [Required] public int SessionId { get; set; }
    }


    public class PrequalifyingAddDto : Mapper<Prequalifying>
    {
        public int? EventId { get; set; }
        public SessionPurpose? SessionPurpose { get; set; }
        public int? SessionId { get; set; }
        public int? PerformancerequirementId { get; set; }
    }


    public class PrequalifyingUpdateDto : PrequalifyingAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class PrequalifyingFilterDto : PrequalifyingAddDto
    {
        public int? Id { get; set; }
        public string? Event { get; set; }
        public string? Session { get; set; }
        public string? Performancerequirement { get; set; }
    }


    public class PrequalifyingFilterDtos
    {
        public PrequalifyingFilterDto Filter { get; set; } = new();
        public PrequalifyingFilterDto FilterMin { get; set; } = new();
        public PrequalifyingFilterDto FilterMax { get; set; } = new();
    }
}
