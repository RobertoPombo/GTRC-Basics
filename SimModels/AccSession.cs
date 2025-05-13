namespace GTRC_Basics.SimModels
{
    public class AccSession
    {
        public byte hourOfDay { get; set; } = byte.MinValue;
        public byte dayOfWeekend { get; set; } = 1;
        public byte timeMultiplier { get; set; } = 1;
        public string sessionType { get; set; } = SessionType.Practice.ToString()[..1];
        public uint sessionDurationMinutes { get; set; } = uint.MinValue;
    }
}
