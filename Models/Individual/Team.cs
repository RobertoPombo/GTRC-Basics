using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Team : IBaseModel
    {
        public static readonly string DefaultName = nameof(Team) + " #1";

        public override string ToString() { return Name + " (" + Organization.Name + ") - " + Season.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Season))] public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        [ForeignKey(nameof(Organization))] public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = new();
    }
}
