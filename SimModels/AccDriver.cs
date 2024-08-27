namespace GTRC_Basics.SimModels
{
    public class AccDriver
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
        public byte driverCategory { get; set; } = (byte)AccDriverCategory.Platinum;
        public string playerID { get; set; } = string.Empty;

        public static string SteamId2PlayerID(ulong steamId) { return "S" + steamId.ToString(); }
    }
}
