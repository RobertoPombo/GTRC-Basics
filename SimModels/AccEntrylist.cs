using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccEntrylist
    {
        public List<AccEntry> entries { get; set; } = [];
        public byte forceEntryList { get; set; }

        public void AddEntry(List<AccDriver> listDrivers, ushort raceNumber, bool isServerAdmin = false, bool forceDriverInfo = false, int forcedCarModel = -1,
            int defaultGridPosition = -1, short ballastKg = 0, short restrictor = 0)
        {
            foreach (AccEntry entry in entries)
            {
                if (entry.raceNumber == raceNumber) { return; }
                foreach (AccDriver driver in entry.drivers)
                {
                    foreach (AccDriver newDriver in listDrivers)
                    {
                        if (driver.playerID == newDriver.playerID) { return; }
                    }
                }
            }
            AccEntry newEntry = new()
            {
                raceNumber = raceNumber,
                forcedCarModel = forcedCarModel,
                overrideDriverInfo = forceDriverInfo ? (byte)1 : (byte)0,
                defaultGridPosition = defaultGridPosition,
                ballastKg = ballastKg,
                restrictor = restrictor,
                isServerAdmin = isServerAdmin ? (byte)1 : (byte)0,
            };
            foreach (AccDriver driver in listDrivers)
            {
                newEntry.AddDriver(Scripts.String2LongSteamId(driver.playerID) ?? GlobalValues.NoSteamId, driver.firstName, driver.lastName, driver.shortName, driver.driverCategory);
            }
            entries.Add(newEntry);
        }

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\entrylist.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
