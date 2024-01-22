using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class User : IBaseModel
    {
        public static readonly short DefaultEloRating = 1500;
        public static readonly short MinEloRating = 0;
        public static readonly short MaxEloRating = 9999;
        public static readonly short DefaultSafetyRating = 50;
        public static readonly short MaxSafetyRating = 100;

        public override string ToString() { return FirstName + " " + LastName; }

        public int Id { get; set; }
        public ulong SteamId { get; set; } = GlobalValues.NoSteamId;
        public ulong DiscordId { get; set; } = GlobalValues.NoDiscordId;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
        public DateTime BanDate { get; set; } = GlobalValues.DateTimeMaxValue;
        public string Name3Digits { get; set; } = string.Empty;
        public short EloRating { get; set; } = DefaultEloRating;
        public short SafetyRating { get; set; } = DefaultSafetyRating;
        public byte Warnings { get; set; } = byte.MinValue;
        public string NickName { get; set; } = string.Empty;
    }
}
