using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class UserRole : IBaseModel
    {
        public override string ToString() { return User.ToString() + " | " + Role.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        [ForeignKey(nameof(Role))] public int RoleId { get; set; }
        public virtual Role Role { get; set; } = new();
    }
}
