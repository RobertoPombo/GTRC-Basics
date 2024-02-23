using Newtonsoft.Json;
using System.Text;

namespace SimModels
{
    public class AccBopEntry
    {
        public string track { get; set; } = string.Empty;
        public uint carModel { get; set; }
        public short ballastKg { get; set; }
        public short restrictor { get; set; }
    }

    public class AccBop
    {
        public List<AccBopEntry> entries { get; set; } = [];

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\bop.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }

        public void Add(string accTrackId, uint accCarId, short ballastKg = 0, short restrictor = 0)
        {
            foreach (AccBopEntry entry in entries)
            {
                if (entry.track == accTrackId && entry.carModel == accCarId) { return; }
            }
            entries.Add(new() { track = accTrackId, carModel = accCarId, ballastKg = ballastKg, restrictor = restrictor });
        }
    }
}
