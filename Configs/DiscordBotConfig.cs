using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.Configs
{
    public class DiscordBotConfig
    {
        private static readonly string path = GlobalValues.ConfigDirectory + "config discord bot.json";
        private static readonly string pathTokens = GlobalValues.ConfigDirectory + "config discord bot tokens.json";
        public static readonly List<DiscordBotConfig> List = [];
        public static readonly string DefaultName = "Discord Bot #1";

        public static Dictionary<ulong, string> Tokens { get; set; } = [];

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

    [JsonIgnore] public string Token { get { if (Tokens.TryGetValue(discordBotId, out string? token)) { return token; } else { return string.Empty; } } }

        public bool IsUniqueName()
        {
            int listIndexThis = List.IndexOf(this);
            for (int botNr = 0; botNr < List.Count; botNr++)
            {
                if (List[botNr].Name == name && botNr != listIndexThis) { return false; }
            }
            return true;
        }

        public static void LoadTokens()
        {
            if (!File.Exists(pathTokens)) { File.WriteAllText(pathTokens, JsonConvert.SerializeObject(Tokens, Formatting.Indented), Encoding.Unicode); }
            try
            {
                Tokens.Clear();
                Tokens = JsonConvert.DeserializeObject<Dictionary<ulong, string>>(File.ReadAllText(pathTokens, Encoding.Unicode)) ?? [];
                GlobalValues.CurrentLogText = "Discord bot tokens loaded.";
            }
            catch { GlobalValues.CurrentLogText = "Load discord bot tokens failed!"; }
        }

        public static void LoadJson()
        {
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

        public static event Notify? ChangedDiscordBotIsActive;

        public static void OnChangedDiscordBotIsActive() { ChangedDiscordBotIsActive?.Invoke(); }
    }
}
