using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Color : IBaseModel
    {
        public override string ToString()
        {
            System.Drawing.Color argb = System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue); 
            return Id.ToString() + ". #" + argb.R.ToString("X2") + argb.G.ToString("X2") + argb.B.ToString("X2");
        }

        public int Id { get; set; }
        public byte Alpha { get; set; } = byte.MinValue;
        public byte Red { get; set; } = byte.MinValue;
        public byte Green { get; set; } = byte.MinValue;
        public byte Blue { get; set; } = byte.MinValue;
    }
}
