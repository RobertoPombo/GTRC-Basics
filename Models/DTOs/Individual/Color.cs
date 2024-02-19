using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GTRC_Basics.Models.DTOs
{
    public class ColorFullDto : Color
    {
        public System.Drawing.Color Preview
        {
            get { return GetPreview(this); }
            set { }
        }

        public static System.Drawing.Color GetPreview(Color obj)
        {
            return System.Drawing.Color.FromArgb(obj.Alpha, obj.Red, obj.Green, obj.Blue);
        }
    }


    public class ColorUniqPropsDto0 : Mapper<Color>
    {
        [Required] public byte Alpha { get; set; } = byte.MinValue;
        [Required] public byte Red { get; set; } = byte.MinValue;
        [Required] public byte Green { get; set; } = byte.MinValue;
        [Required] public byte Blue { get; set; } = byte.MinValue;
    }


    public class ColorAddDto : Mapper<Color>
    {
        public byte? Alpha { get; set; }
        public byte? Red { get; set; }
        public byte? Green { get; set; }
        public byte? Blue { get; set; }
    }


    public class ColorUpdateDto : ColorAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class ColorFilterDto : ColorAddDto
    {
        public int? Id { get; set; }
    }


    public class ColorFilterDtos
    {
        public ColorFilterDto Filter { get; set; } = new();
        public ColorFilterDto FilterMin { get; set; } = new();
        public ColorFilterDto FilterMax { get; set; } = new();
    }
}
