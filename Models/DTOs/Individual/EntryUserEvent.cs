using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EntryUserEventFullDto : EntryUserEvent
    {

    }


    public class EntryUserEventUniqPropsDto0 : Mapper<EntryUserEvent>
    {
        [Required] public int EntryId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public int EventId { get; set; }
    }


    public class EntryUserEventAddDto : Mapper<EntryUserEvent>
    {
        public int? EntryId { get; set; }
        public int? UserId { get; set; }
        public int? EventId { get; set; }
        public string? Name3Digits { get; set; }
    }


    public class EntryUserEventUpdateDto : EntryUserEventAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EntryUserEventFilterDto : EntryUserEventAddDto
    {
        public int? Id { get; set; }
        public string? Entry { get; set; }
        public string? User { get; set; }
        public string? Event { get; set; }
    }


    public class EntryUserEventFilterDtos
    {
        public EntryUserEventFilterDto Filter { get; set; } = new();
        public EntryUserEventFilterDto FilterMin { get; set; } = new();
        public EntryUserEventFilterDto FilterMax { get; set; } = new();
    }
}
