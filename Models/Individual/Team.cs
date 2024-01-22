using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Team : IBaseModel
    {
        public static readonly string DefaultName = nameof(Team) + " #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        [ForeignKey(nameof(Organization))] public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = new();
    }
}
