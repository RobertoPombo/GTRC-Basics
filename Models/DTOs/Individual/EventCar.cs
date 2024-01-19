using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EventCarFullDto : EventCar
    {

    }


    public class EventCarUniqPropsDto0 : Mapper<EventCar>
    {
        [Required] public int EventId { get; set; }
        [Required] public int CarId { get; set; }
    }


    public class EventCarAddDto : Mapper<EventCar>
    {
        public int? EventId { get; set; }
        public int? CarId { get; set; }
        public short? BallastKg { get; set; }
        public short? Restrictor { get; set; }
        public byte? Count { get; set; }
        public byte? CountBop { get; set; }
    }


    public class EventCarUpdateDto : EventCarAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EventCarFilterDto : EventCarAddDto
    {
        public int? Id { get; set; }
        public string? Event { get; set; }
        public string? Car { get; set; }
    }


    public class EventCarFilterDtos
    {
        public EventCarFilterDto Filter { get; set; } = new();
        public EventCarFilterDto FilterMin { get; set; } = new();
        public EventCarFilterDto FilterMax { get; set; } = new();
    }
}
