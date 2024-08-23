using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.Configs
{
    public class DatabaseBackupConfig
    {
        private static readonly string path = GlobalValues.ConfigDirectory + "config database backup.json";
        private static readonly int refreshIntervalSecMin = 1;
        private static readonly int refreshIntervalSecMax = 3600;
        private static readonly int intervallCreateHMin = 1;
        private static readonly int intervallCreateHMax = 8760;
        private static readonly int intervallDeleteDMin = 1;
        private static readonly int intervallDeleteDMax = 3650;

        private int refreshIntervalSec = refreshIntervalSecMin;
        private int intervalCreateH = intervallCreateHMin;
        private int intervalDeleteD = intervallDeleteDMin;

        public int RefreshIntervalSec
        {
            get { return refreshIntervalSec; }
            set { refreshIntervalSec = Math.Min(refreshIntervalSecMax, Math.Max(refreshIntervalSecMin, value)); }
        }

        public int IntervalCreateH
        {
            get { return intervalCreateH; }
            set { intervalCreateH = Math.Min(intervallCreateHMax, Math.Max(intervallCreateHMin, value)); }
        }

        public int IntervalDeleteD
        {
            get { return intervalDeleteD; }
            set { intervalDeleteD = Math.Min(intervallDeleteDMax, Math.Max(intervallDeleteDMin, value)); }
        }

        public bool IsActiveCreate { get; set; } = false;

        public bool IsActiveDelete { get; set; } = false;

        public static DatabaseBackupConfig LoadJson()
        {
            DatabaseBackupConfig? config = null;
            if (!File.Exists(path)) { File.WriteAllText(path, JsonConvert.SerializeObject(new DatabaseBackupConfig(), Formatting.Indented), Encoding.Unicode); }
            try
            {
                config = JsonConvert.DeserializeObject<DatabaseBackupConfig>(File.ReadAllText(path, Encoding.Unicode));
                GlobalValues.CurrentLogText = "Json backup settings restored.";
            }
            catch { GlobalValues.CurrentLogText = "Restore json backup settings failed!"; }
            config ??= new DatabaseBackupConfig();
            return config;
        }

        public static void SaveJson(DatabaseBackupConfig config)
        {
            string text = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
            GlobalValues.CurrentLogText = "Json backup settings saved.";
        }
    }
}
