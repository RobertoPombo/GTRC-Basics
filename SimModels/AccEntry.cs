namespace GTRC_Basics.SimModels
{
    public class AccEntry
    {
        public List<AccDriver> drivers { get; set; } = [];
        public ushort raceNumber { get; set; }
        public int forcedCarModel { get; set; }
        public byte overrideDriverInfo { get; set; }
        public int defaultGridPosition { get; set; }
        public short ballastKg { get; set; }
        public short restrictor { get; set; }
        public byte isServerAdmin { get; set; }

        public void AddDriver(ulong steamId, string firstName, string lastName, string name3Digits, byte accDriverCategory = (byte)AccDriverCategory.Platinum)
        {
            foreach (AccDriver driver in drivers) { if (driver.playerID == AccDriver.SteamId2PlayerID(steamId)) { return; } }
            drivers.Add(new() {
                firstName = firstName,
                lastName = lastName,
                shortName = name3Digits,
                driverCategory = accDriverCategory,
                playerID = AccDriver.SteamId2PlayerID(steamId)
            });
        }
    }
}
