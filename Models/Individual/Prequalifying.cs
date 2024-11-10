using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Prequalifying : IBaseModel
    {
        public override string ToString() { return SessionPurpose.ToString() + " | " + Event.ToString() + " | " + Session.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Event))] public int EventId { get; set; }
        public virtual Event Event { get; set; } = new();
        public SessionPurpose SessionPurpose { get; set; } = SessionPurpose.PreQualifying;
        [ForeignKey(nameof(Session))] public int SessionId { get; set; }
        public virtual Session Session { get; set; } = new();
        [ForeignKey(nameof(Performancerequirement))] public int PerformancerequirementId { get; set; }
        public virtual Performancerequirement Performancerequirement { get; set; } = new();
    }
}
