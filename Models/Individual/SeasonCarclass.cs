using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class SeasonCarclass : IBaseModel
    {
        public override string ToString() { return Season.ToString() + " | " + Carclass.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Season))] public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = new();
        [ForeignKey(nameof(Carclass))] public int CarclassId { get; set; }
        public virtual Carclass Carclass { get; set; } = new();
        public byte MaxGridSlots { get; set; } = byte.MaxValue;
    }
}
