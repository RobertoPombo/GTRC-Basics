using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Series : IBaseModel
    {
        public static readonly string DefaultName = nameof(Series) + " #1";

        public override string ToString() { return Id.ToString() + ". " + Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        [ForeignKey(nameof(Sim))] public int SimId { get; set; }
        public virtual Sim Sim { get; set; } = new();
    }
}
