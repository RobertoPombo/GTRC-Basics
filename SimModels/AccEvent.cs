using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccEvent
    {
        public string track { get; set; } = string.Empty;
        public ushort preRaceWaitingTimeSeconds { get; set; } = ushort.MinValue;
        public ushort sessionOverTimeSeconds { get; set; } = ushort.MinValue;
        public short ambientTemp { get; set; } = 0;
        public decimal cloudLevel { get; set; } = 0;
        public decimal rain { get; set; } = 0;
        public byte weatherRandomness { get; set; } = byte.MinValue;
        public byte configVersion { get; set; } = 1;
        public List<AccSession> sessions { get; set; } = [];

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\event.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
