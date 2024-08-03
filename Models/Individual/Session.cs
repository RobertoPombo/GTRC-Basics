using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Session : IBaseModel
    {
        public static readonly string DefaultServerName = nameof(Server) + " #1";
        public static readonly string DefaultPassword = "123";

        public override string ToString() { return SessionType.ToString() + " - " + (Event.Date + StartTime).ToString() + " - " + Event.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        public TimeSpan StartTime { get; set; } = TimeSpan.Zero;
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(1);
        public TimeSpan IngameDuration { get; set; } = TimeSpan.FromMinutes(1);
        public SessionType SessionType { get; set; } = SessionType.Practice;
        public bool IsObligatedAttendance { get; set; } = false;
        [ForeignKey(nameof(Pointssystem))] public int PointssystemId { get; set; }
        public virtual Pointssystem Pointssystem { get; set; } = new();
        public int PreviousSessionId { get; set; } = GlobalValues.NoId;
        public int GridSessionId { get; set; } = GlobalValues.NoId;
        public byte ReverseGridFrom { get; set; } = 1;
        public byte ReverseGridTo { get; set; } = 1;
        public byte IngameStartTimeHour { get; set; } = byte.MinValue;
        public byte DayOfWeekend { get; set; } = 1;
        public byte TimeMultiplier { get; set; } = 1;
        public EntrylistType EntrylistType { get; set; } = EntrylistType.None;
        public bool ForceEntrylist { get; set; } = false;
        public bool ForceDriverInfo { get; set; } = false;
        public bool ForceCarModel { get; set; } = false;
        public bool WriteBoP { get; set; } = false;
        public string ServerName { get; set; } = DefaultServerName;
        public string DriverPassword { get; set; } = DefaultPassword;
        public string SpectatorPassword { get; set; } = DefaultPassword;
        public string AdminPassword { get; set; } = DefaultPassword;
    }
}
