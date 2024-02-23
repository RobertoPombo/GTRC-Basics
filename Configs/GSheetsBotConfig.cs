using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.Configs
{
    public class GSheetsBotConfig
    {
        private static readonly string path = GlobalValues.DataDirectory + "config googlesheets bot.json";

        private int intervallMin = 0;

        public int SeriesId { get; set; }

        public int SeasonId { get; set; }

        public int IntervallMin
        {
            get { return intervallMin; }
            set { intervallMin = Math.Min(1440, Math.Max(1, value)); }
        }

        public bool IsActive { get; set; } = false;

        public static GSheetsBotConfig LoadJson()
        {
            GSheetsBotConfig? gSheetsBotConfig = null;
            if (!Directory.Exists(GlobalValues.DataDirectory)) { Directory.CreateDirectory(GlobalValues.DataDirectory); }
            if (!File.Exists(path)) { File.WriteAllText(path, JsonConvert.SerializeObject(new GSheetsBotConfig(), Formatting.Indented), Encoding.Unicode); }
            try
            {
                gSheetsBotConfig = JsonConvert.DeserializeObject<GSheetsBotConfig>(File.ReadAllText(path, Encoding.Unicode));
                GlobalValues.CurrentLogText = "Google-Sheets bot settings restored.";
            }
            catch { GlobalValues.CurrentLogText = "Restore Google-Sheets bot settings failed!"; }
            gSheetsBotConfig ??= new GSheetsBotConfig();
            return gSheetsBotConfig;
        }

        public static void SaveJson(GSheetsBotConfig gSheetsBotConfig)
        {
            string text = JsonConvert.SerializeObject(gSheetsBotConfig, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
            GlobalValues.CurrentLogText = "Google-Sheets bot settings saved.";
        }
    }
}
