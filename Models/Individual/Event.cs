using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Event : IBaseModel
    {
        public static readonly string DefaultName = nameof(Event);
        public static readonly ushort DefaultSessionOvertimeSeconds = 140;
        public static readonly ushort DefaultPreRaceWaitingTimeSeconds = 120;
        public static readonly ushort DefaultPostQualiSeconds = 30;
        public static readonly ushort DefaultPostRaceSeconds = 140;

        public override string ToString() { return Name + " - " + Season.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Season))] public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Track))] public int TrackId { get; set; }
        public virtual Track Track { get; set; } = new();
        public ResultsCombinationType PrequalifyingCombinationType { get; set; } = ResultsCombinationType.Average;
        public ushort SessionOvertimeSeconds { get; set; } = DefaultSessionOvertimeSeconds;
        public ushort PreRaceWaitingTimeSeconds { get; set; } = DefaultPreRaceWaitingTimeSeconds;
        public ushort PostQualiSeconds { get; set; } = DefaultPostQualiSeconds;
        public ushort PostRaceSeconds { get; set; } = DefaultPostRaceSeconds;
    }
}
