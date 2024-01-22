using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class OrganizationUser : IBaseModel
    {
        public override string ToString() { return Organization.ToString() + " | " + User.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Organization))] public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = new();
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        public bool IsAdmin { get; set; } = false;
        public bool IsInvited { get; set; } = true;
    }
}
