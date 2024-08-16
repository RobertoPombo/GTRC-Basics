using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.Configs
{
    public class DiscordBotConfig
    {
        private static readonly Dictionary<ulong, string> tokens = new()
        {
            { 1004795316463227040, "MTAwNDc5NTMxNjQ2MzIyNzA0MA.G4Qg1w.-_7ccWcVoZrun6jx-k_7KreF-1fE-blNNhrJzc" },
            { 1008400523390636184, "MTAwODQwMDUyMzM5MDYzNjE4NA.GuiMFH.L0A38VZ9n1enIUMCyAn5-HTqVlLl99XzsqFLW0" },
        };
        private static readonly string path = GlobalValues.DataDirectory + "config discordBot.json";
        public static readonly List<DiscordBotConfig> List = [];
        public static readonly string DefaultName = "Discord Bot #1";

        public DiscordBotConfig()
        {
            List.Add(this);
            Name = name;
        }

        private string name = DefaultName;
        private ulong discordBotId = GlobalValues.NoDiscordId;
        private ulong discordServerId = GlobalValues.NoDiscordId;
        private ushort charLimit = ushort.MaxValue;
        private bool isActive = false;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 0)
                {
                    name = value;
                    int nr = 1;
                    string delimiter = " #";
                    string defName = name;
                    string[] defNameList = defName.Split(delimiter);
                    if (defNameList.Length > 1 && int.TryParse(defNameList[^1], out _)) { defName = defName[..^(defNameList[^1].Length + delimiter.Length)]; }
                    while (!IsUniqueName())
                    {
                        name = defName + delimiter + nr.ToString();
                        nr++; if (nr == int.MaxValue) { break; }
                    }
                }
            }
        }

        public ulong DiscordBotId
        {
            get { return discordBotId; }
            set { discordBotId = value; }
        }

        public ulong DiscordServerId { get { return discordServerId; } set { if (Scripts.IsValidDiscordId(value)) { discordServerId = value; } } }

        public ushort CharLimit { get { return charLimit; } set { charLimit = value; } }

        public bool IsActive
        {
            get { return isActive; }
            set { if (value != isActive) { if (value) { DeactivateAllBots(); } isActive = value; if (Token == string.Empty) { isActive = false; } } }
        }

        [JsonIgnore] public string Token { get { if (tokens.TryGetValue(discordBotId, out string? token)) { return token; } else { return string.Empty; } } }

        public bool IsUniqueName()
        {
            int listIndexThis = List.IndexOf(this);
            for (int botNr = 0; botNr < List.Count; botNr++)
            {
                if (List[botNr].Name == name && botNr != listIndexThis) { return false; }
            }
            return true;
        }

        public static void LoadJson()
        {
            if (!Directory.Exists(GlobalValues.DataDirectory)) { Directory.CreateDirectory(GlobalValues.DataDirectory); }
            if (!File.Exists(path)) { File.WriteAllText(path, JsonConvert.SerializeObject(List, Formatting.Indented), Encoding.Unicode); }
            try
            {
                List.Clear();
                _ = JsonConvert.DeserializeObject<List<DiscordBotConfig>>(File.ReadAllText(path, Encoding.Unicode)) ?? [];
                GlobalValues.CurrentLogText = "Discord bot settings restored.";
            }
            catch { GlobalValues.CurrentLogText = "Restore discord bot settings failed!"; }
            if (List.Count == 0) { _ = new DiscordBotConfig(); }
        }

        public static void SaveJson()
        {
            string text = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
            GlobalValues.CurrentLogText = "Discord bot settings saved.";
        }

        public static DiscordBotConfig? GetActiveBot()
        {
            foreach (DiscordBotConfig bot in List) { if (bot.IsActive) { return bot; } }
            return null;
        }

        public static void DeactivateAllBots()
        {
            DiscordBotConfig? bot = GetActiveBot();
            if (bot is not null) { bot.IsActive = false; }
        }
    }
}
