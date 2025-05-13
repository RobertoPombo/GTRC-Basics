using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccSettings
    {
        public string serverName { get; set; } = string.Empty;
        public string adminPassword { get; set; } = string.Empty;
        public string carGroup { get; set; } = string.Empty;
        public short trackMedalsRequirement { get; set; } = -1;
        public short safetyRatingRequirement { get; set; } = -1;
        public short racecraftRatingRequirement { get; set; } = -1;
        public string password { get; set; } = string.Empty;
        public string spectatorPassword { get; set; } = string.Empty;
        public byte maxCarSlots { get; set; } = byte.MaxValue;
        public byte dumpLeaderboards { get; set; } = 1;
        public byte isRaceLocked { get; set; } = 1;
        public byte randomizeTrackWhenEmpty { get; set; } = 0;
        public string centralEntryListPath { get; set; } = string.Empty;
        public byte allowAutoDQ { get; set; } = 0;
        public byte shortFormationLap { get; set; } = 0;
        public byte dumpEntryList { get; set; } = 1;
        public byte formationLapType { get; set; } = 1;

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\settings.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
