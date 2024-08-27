using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.SimModels
{
    public class AccBop
    {
        public List<AccTrackCar> entries { get; set; } = [];

        public void AddEntry(string accTrackId, uint accCarId, short ballastKg = 0, short restrictor = 0)
        {
            foreach (AccTrackCar trackCar in entries)
            {
                if (trackCar.track == accTrackId && trackCar.carModel == accCarId) { return; }
            }
            entries.Add(new() { track = accTrackId, carModel = accCarId, ballastKg = ballastKg, restrictor = restrictor });
        }

        public void WriteJson(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            path += "\\bop.json";
            string text = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
        }
    }
}
