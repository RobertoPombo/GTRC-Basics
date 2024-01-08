using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class User : IBaseModel
    {
        public static readonly ulong NoDiscordId = ulong.MinValue;
        public static readonly ulong MinSteamId = (ulong)Math.Pow(10, 16);
        public static readonly ulong MaxSteamId = MinSteamId * 10 - 1;
        public static readonly ulong MinDiscordId = (ulong)Math.Pow(10, 17);
        public static readonly ulong MaxDiscordId = ulong.MaxValue;
        public static readonly short DefaultEloRating = 1500;
        public static readonly short MinEloRating = 0;
        public static readonly short MaxEloRating = 9999;
        public static readonly short DefaultSafetyRating = 50;
        public static readonly short MaxSafetyRating = 100;

        public int Id { get; set; }
        public ulong SteamId { get; set; } = MinSteamId;
        public ulong DiscordId { get; set; } = ulong.MinValue;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
        public DateTime BanDate { get; set; } = GlobalValues.DateTimeMaxValue;
        public string Name3Digits { get; set; } = string.Empty;
        public short EloRating { get; set; } = DefaultEloRating;
        public short SafetyRating { get; set; } = DefaultSafetyRating;
        public byte Warnings { get; set; } = byte.MinValue;
        public string UserName { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
