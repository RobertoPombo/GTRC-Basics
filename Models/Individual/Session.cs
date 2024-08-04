using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Session : IBaseModel
    {
        public static readonly int DefaultStartTimeOffsetMin = 0;
        public static readonly ushort MinDurationMin = 1;
        public static readonly ushort MinSessionsCount = 1;
        public static readonly byte MinReverseGridFrom = 1;
        public static readonly byte MinDayOfWeekend = 1;
        public static readonly byte MaxDayOfWeekend = 3;
        public static readonly byte MinTimeMultiplier = 1;
        public static readonly byte MaxTimeMultiplier = 24;
        public static readonly string DefaultServerName = nameof(Server) + " #1";
        public static readonly byte MinCharacterCountPassword = 3;

        public override string ToString() { return SessionType.ToString() + " - " + Event.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        public int StartTimeOffsetMin { get; set; } = DefaultStartTimeOffsetMin;
        public ushort DurationMin { get; set; } = MinDurationMin;
        public ushort SessionsCount { get; set; } = MinSessionsCount;
        public bool IsAllowedInterruption { get; set; } = false;
        public SessionType SessionType { get; set; } = SessionType.Practice;
        public bool IsObligatedAttendance { get; set; } = false;
        [ForeignKey(nameof(StintAnalysisMethod))] public int StintAnalysisMethodId { get; set; }
        public virtual StintAnalysisMethod StintAnalysisMethod { get; set; } = new();
        [ForeignKey(nameof(Pointssystem))] public int PointssystemId { get; set; }
        public virtual Pointssystem Pointssystem { get; set; } = new();
        public int PreviousSessionId { get; set; } = GlobalValues.NoId;
        public int GridSessionId { get; set; } = GlobalValues.NoId;
        public byte ReverseGridFrom { get; set; } = MinReverseGridFrom;
        public byte ReverseGridTo { get; set; } = MinReverseGridFrom;
        public byte IngameStartTimeHour { get; set; } = byte.MinValue;
        public byte DayOfWeekend { get; set; } = MinDayOfWeekend;
        public byte TimeMultiplier { get; set; } = MinTimeMultiplier;
        public EntrylistType EntrylistType { get; set; } = EntrylistType.None;
        public bool ForceEntrylist { get; set; } = false;
        public bool ForceDriverInfo { get; set; } = false;
        public bool ForceCarModel { get; set; } = false;
        public bool WriteBoP { get; set; } = false;
        public string ServerName { get; set; } = DefaultServerName;
        public string DriverPassword { get; set; } = string.Empty;
        public string SpectatorPassword { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
    }
}
