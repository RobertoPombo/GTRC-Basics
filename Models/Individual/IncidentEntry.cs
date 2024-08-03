using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class IncidentEntry : IBaseModel
    {
        public override string ToString() { return Entry.ToString() + " - " + Incident.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Incident))] public int IncidentId { get; set; }
        public virtual Incident Incident { get; set; } = new();
        [ForeignKey(nameof(Entry))] public int EntryId { get; set; }
        public virtual Entry Entry { get; set; } = new();
        [ForeignKey(nameof(User))] public int UserId { get; set; }
        public virtual User User { get; set; } = new();
        public bool IsAtFault { get; set; } = false;
    }
}
