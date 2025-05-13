using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccAssistRules
    {
        public byte stabilityControlLevelMax { get; set; } = byte.MinValue;
        public byte disableAutosteer { get; set; } = 1;
        public byte disableAutoLights { get; set; } = 1;
        public byte disableAutoWiper { get; set; } = 1;
        public byte disableAutoEngineStart { get; set; } = 1;
        public byte disableAutoPitLimiter { get; set; } = 1;
        public byte disableAutoGear { get; set; } = 1;
        public byte disableAutoClutch { get; set; } = 1;
        public byte disableIdealLine { get; set; } = 1;

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\assistRules.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
