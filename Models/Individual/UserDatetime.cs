using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class UserDatetime : IBaseModel
    {
        public override string ToString() { return User.ToString() + " | " + Date.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public short EloRating { get; set; } = User.DefaultEloRating;
        public short SafetyRating { get; set; } = User.DefaultSafetyRating;
        public byte Warnings { get; set; } = byte.MinValue;
    }
}
