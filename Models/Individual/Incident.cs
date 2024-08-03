using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Incident : IBaseModel
    {
        public override string ToString() { return Scripts.Ms2Laptime(TimeStampMs).ToString() + " - " + Session.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Session))] public int SessionId { get; set; }
        public virtual Session Session { get; set; } = new();
        public uint TimeStampMs { get; set; } = uint.MinValue;
        public uint ReplayTimeMs { get; set; } = uint.MinValue;
        public ReportReason ReportReason { get; set; } = ReportReason.ManualReport;
        public ushort EloRatingPenalty { get; set; } = ushort.MinValue;
        public ushort SafetyRatingPenalty { get; set; } = ushort.MinValue;
        public bool WarningPenalty { get; set; } = false;
        public ushort TimePenalty { get; set; } = ushort.MinValue;
        public ushort TimeLoss { get; set; } = ushort.MinValue;
        public IncidentStatus Status { get; set; } = IncidentStatus.Open;
        public bool IsApplied { get; set; } = false;
    }
}
