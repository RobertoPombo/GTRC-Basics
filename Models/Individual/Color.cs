using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Color : IBaseModel
    {
        public override string ToString() { return Id.ToString(); }

        public int Id { get; set; }
        public byte Alpha { get; set; } = byte.MinValue;
        public byte Red { get; set; } = byte.MinValue;
        public byte Green { get; set; } = byte.MinValue;
        public byte Blue { get; set; } = byte.MinValue;
    }
}
