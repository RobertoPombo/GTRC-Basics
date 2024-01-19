using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EventCarclassFullDto : EventCarclass
    {

    }


    public class EventCarclassUniqPropsDto0 : Mapper<EventCarclass>
    {
        [Required] public int EventId { get; set; }
        [Required] public int CarclassId { get; set; }
    }


    public class EventCarclassAddDto : Mapper<EventCarclass>
    {
        public int? EventId { get; set; }
        public int? CarclassId { get; set; }
    }


    public class EventCarclassUpdateDto : EventCarclassAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EventCarclassFilterDto : EventCarclassAddDto
    {
        public int? Id { get; set; }
        public string? Event { get; set; }
        public string? Carclass { get; set; }
    }


    public class EventCarclassFilterDtos
    {
        public EventCarclassFilterDto Filter { get; set; } = new();
        public EventCarclassFilterDto FilterMin { get; set; } = new();
        public EventCarclassFilterDto FilterMax { get; set; } = new();
    }
}
