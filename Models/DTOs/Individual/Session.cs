using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SessionFullDto : Session
    {
        public DateTime StartDate
        {
            get { return GetStartDate(this); }
            set { }
        }

        public DateTime EndDate
        {
            get { return GetEndDate(this); }
            set { }
        }

        public static DateTime GetStartDate(Session obj)
        {
            return obj.Event.Date.AddMinutes(obj.StartTimeOffsetMin);
        }

        public static DateTime GetEndDate(Session obj)
        {
            return obj.Event.Date.AddMinutes(obj.StartTimeOffsetMin + obj.SessionsCount * obj.DurationMin);
        }
    }


    public class SessionUniqPropsDto0 : Mapper<Session>
    {
        [Required] public int EventId { get; set; }
        [Required] public int StartTimeOffsetMin { get; set; } = Session.DefaultStartTimeOffsetMin;
    }


    public class SessionAddDto : Mapper<Session>
    {
        public int? EventId { get; set; }
        public int? StartTimeOffsetMin { get; set; }
        public ushort? DurationMin { get; set; }
        public ushort? SessionsCount { get; set; }
        public bool? IsAllowedInterruption { get; set; }
        public SessionType? SessionType { get; set; }
        public bool? IsObligatedAttendance { get; set; }
        public int? StintanalysismethodId { get; set; }
        public int? PointssystemId { get; set; }
        public int? PreviousSessionId { get; set; }
        public int? GridSessionId { get; set; }
        public byte? ReverseGridFrom { get; set; }
        public byte? ReverseGridTo { get; set; }
        public byte? IngameStartTimeHour { get; set; }
        public byte? DayOfWeekend { get; set; }
        public byte? TimeMultiplier { get; set; }
        public short? AmbientTemp { get; set; }
        public byte? CloudLevel { get; set; }
        public byte? RainLevel { get; set; }
        public byte? WeatherRandomness { get; set; }
        public bool? FixedConditions { get; set; }
        public EntrylistType? EntrylistType { get; set; }
        public bool? ForceEntrylist { get; set; }
        public bool? ForceDriverInfo { get; set; }
        public bool? ForceCarModel { get; set; }
        public bool? WriteBop { get; set; }
        public string? ServerName { get; set; }
        public string? DriverPassword { get; set; }
        public string? SpectatorPassword { get; set; }
        public string? AdminPassword { get; set; }
    }


    public class SessionUpdateDto : SessionAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class SessionFilterDto : SessionAddDto
    {
        public int? Id { get; set; }
        public string? Event { get; set; }
        public string? Stintanalysismethod { get; set; }
        public string? Pointssystem { get; set; }
    }


    public class SessionFilterDtos
    {
        public SessionFilterDto Filter { get; set; } = new();
        public SessionFilterDto FilterMin { get; set; } = new();
        public SessionFilterDto FilterMax { get; set; } = new();
    }
}
