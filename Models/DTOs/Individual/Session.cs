using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class SessionFullDto : Session
    {

    }


    public class SessionAddDto : Mapper<Session>
    {
        public int? EventId { get; set; }
        public ushort? StartTimeOffsetMin { get; set; }
        public ushort? DurationMin { get; set; }
        public ushort? SessionsCount { get; set; }
        public SessionType? SessionType { get; set; }
        public bool? IsObligatedAttendance { get; set; }
        public int? PointssystemId { get; set; }
        public int? PreviousSessionId { get; set; }
        public int? GridSessionId { get; set; }
        public byte? ReverseGridFrom { get; set; }
        public byte? ReverseGridTo { get; set; }
        public byte? IngameStartTimeHour { get; set; }
        public byte? DayOfWeekend { get; set; }
        public byte? TimeMultiplier { get; set; }
        public EntrylistType? EntrylistType { get; set; }
        public bool? ForceEntrylist { get; set; }
        public bool? ForceDriverInfo { get; set; }
        public bool? ForceCarModel { get; set; }
        public bool? WriteBoP { get; set; }
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
        public string? Pointssystem { get; set; }
    }


    public class SessionFilterDtos
    {
        public SessionFilterDto Filter { get; set; } = new();
        public SessionFilterDto FilterMin { get; set; } = new();
        public SessionFilterDto FilterMax { get; set; } = new();
    }
}
