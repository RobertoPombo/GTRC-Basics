using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccConfiguration
    {
        public ushort udpPort { get; set; } = ushort.MinValue;
        public ushort tcpPort { get; set; } = ushort.MinValue;
        public ushort maxConnections { get; set; } = ushort.MaxValue;
        public byte lanDiscovery { get; set; } = byte.MinValue;
        public byte registerToLobby { get; set; } = 1;
        public string publicIP { get; set; } = string.Empty;
        public byte configVersion { get; set; } = 1;

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\configuration.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
