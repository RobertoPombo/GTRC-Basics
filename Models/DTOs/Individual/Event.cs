using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EventFullDto : Event
    {

    }


    public class EventUniqPropsDto0 : Mapper<Event>
    {
        [Required] public int SeasonId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class EventUniqPropsDto1 : Mapper<Event>
    {
        [Required] public int SeasonId { get; set; }
        [Required] public DateTime Date { get; set; } = DateTime.MinValue;
    }


    public class EventAddDto : Mapper<Event>
    {
        public int? SeasonId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public int? TrackId { get; set; }
        public bool? IsPreQualifying { get; set; }
        public short? AmbientTemp { get; set; }
        public byte? CloudLevel { get; set; }
        public byte? RainLevel { get; set; }
        public byte? WeatherRandomness { get; set; }
        public bool? FixedConditions { get; set; }
        public ushort? SessionOvertimeSeconds { get; set; }
        public ushort? PreRaceWaitingTimeSeconds { get; set; }
        public ushort? PostQualiSeconds { get; set; }
        public ushort? PostRaceSeconds { get; set; }
    }


    public class EventUpdateDto : EventAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EventFilterDto : EventAddDto
    {
        public int? Id { get; set; }
        public string? Season { get; set; }
        public string? Track { get; set; }
    }


    public class EventFilterDtos
    {
        public EventFilterDto Filter { get; set; } = new();
        public EventFilterDto FilterMin { get; set; } = new();
        public EventFilterDto FilterMax { get; set; } = new();
    }
}
