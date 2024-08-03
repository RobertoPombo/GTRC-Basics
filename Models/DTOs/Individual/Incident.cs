using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class IncidentFullDto : Incident
    {

    }


    public class IncidentAddDto : Mapper<Incident>
    {
        public int? SessionId { get; set; }
        public uint? TimeStampMs { get; set; }
        public uint? ReplayTimeMs { get; set; }
        public ReportReason? ReportReason { get; set; }
        public ushort? EloRatingPenalty { get; set; }
        public ushort? SafetyRatingPenalty { get; set; }
        public bool? WarningPenalty { get; set; }
        public ushort? TimePenalty { get; set; }
        public ushort? TimeLoss { get; set; }
        public IncidentStatus? Status { get; set; }
        public bool? IsApplied { get; set; }
    }


    public class IncidentUpdateDto : IncidentAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class IncidentFilterDto : IncidentAddDto
    {
        public int? Id { get; set; }
        public string? Session { get; set; }
    }


    public class IncidentFilterDtos
    {
        public IncidentFilterDto Filter { get; set; } = new();
        public IncidentFilterDto FilterMin { get; set; } = new();
        public IncidentFilterDto FilterMax { get; set; } = new();
    }
}
