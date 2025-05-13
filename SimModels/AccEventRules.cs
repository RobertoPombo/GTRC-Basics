using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccEventRules
    {
        public byte qualifyStandingType { get; set; } = 1;
        public short pitWindowLengthSec { get; set; } = -1;
        public short driverStintTimeSec { get; set; } = -1;
        public byte mandatoryPitstopCount { get; set; } = byte.MinValue;
        public short maxTotalDrivingTime { get; set; } = -1;
        public byte maxDriversCount { get; set; } = byte.MaxValue;
        public bool isRefuellingAllowedInRace { get; set; } = true;
        public bool isRefuellingTimeFixed { get; set; } = false;
        public bool isMandatoryPitstopRefuellingRequired { get; set; } = false;
        public bool isMandatoryPitstopTyreChangeRequired { get; set; } = false;
        public bool isMandatoryPitstopSwapDriverRequired { get; set; } = false;
        public byte tyreSetCount { get; set; } = 50;

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\eventRules.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
