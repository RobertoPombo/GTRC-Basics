using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class IncidentEntryFullDto : IncidentEntry
    {

    }


    public class IncidentEntryUniqPropsDto0 : Mapper<IncidentEntry>
    {
        [Required] public int IncidentId { get; set; }
        [Required] public int EntryId { get; set; }
    }


    public class IncidentEntryAddDto : Mapper<IncidentEntry>
    {
        public int? IncidentId { get; set; }
        public int? EntryId { get; set; }
        public int? UserId { get; set; }
        public bool? IsAtFault { get; set; }
    }


    public class IncidentEntryUpdateDto : IncidentEntryAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class IncidentEntryFilterDto : IncidentEntryAddDto
    {
        public int? Id { get; set; }
        public string? Incident { get; set; }
        public string? Entry { get; set; }
        public string? User { get; set; }
    }


    public class IncidentEntryFilterDtos
    {
        public IncidentEntryFilterDto Filter { get; set; } = new();
        public IncidentEntryFilterDto FilterMin { get; set; } = new();
        public IncidentEntryFilterDto FilterMax { get; set; } = new();
    }
}
