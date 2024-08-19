using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class User : IBaseModel
    {
        public override string ToString() { return FirstName + " " + LastName; }

        public int Id { get; set; }
        public ulong SteamId { get; set; } = GlobalValues.NoSteamId;
        public ulong DiscordId { get; set; } = GlobalValues.NoDiscordId;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
        public DateTime BanDate { get; set; } = GlobalValues.DateTimeMaxValue;
        public string Name3Digits { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
    }
}
