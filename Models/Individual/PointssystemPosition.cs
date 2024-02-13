using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class PointssystemPosition : IBaseModel
    {
        public static readonly byte MinPosition = 1;

        public override string ToString() { return Pointssystem.ToString() + " | " + Position.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Pointssystem))] public int PointssystemId { get; set; }
        public virtual Pointssystem Pointssystem { get; set; } = new();
        public byte Position { get; set; } = MinPosition;
        public short Points { get; set; }
    }
}
