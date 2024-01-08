using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Color : IBaseModel
    {
        public int Id { get; set; }
        public Byte Alpha { get; set; } = Byte.MinValue;
        public Byte Red { get; set; } = Byte.MinValue;
        public Byte Green { get; set; } = Byte.MinValue;
        public Byte Blue { get; set; } = Byte.MinValue;
    }
}
