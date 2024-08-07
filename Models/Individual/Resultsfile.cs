using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Resultsfile : IBaseModel
    {
        public override string ToString() { return Session.ToString() + " - " + Date.ToString(); }

        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey(nameof(Server))] public int ServerId { get; set; }
        public virtual Server Server { get; set; } = new();
        [ForeignKey(nameof(Session))] public int SessionId { get; set; }
        public virtual Session Session { get; set; } = new();
    }
}
