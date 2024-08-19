using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class UserDatetime : IBaseModel
    {
        public static readonly short DefaultEloRating = 1500;
        public static readonly short MinEloRating = 0;
        public static readonly short MaxEloRating = 9999;
        public static readonly short DefaultSafetyRating = 50;
        public static readonly short MaxSafetyRating = 100;

        public override string ToString() { return User.ToString() + " | " + Date.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public short EloRating { get; set; } = DefaultEloRating;
        public short SafetyRating { get; set; } = DefaultSafetyRating;
        public byte Warnings { get; set; } = byte.MinValue;
    }
}
