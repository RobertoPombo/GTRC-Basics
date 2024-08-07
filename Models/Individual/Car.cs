using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Car : IBaseModel
    {
        public static readonly string DefaultName = nameof(Car);
        public static readonly ushort MinWidthMm = 1;
        public static readonly ushort MinLengthMm = 1;

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public uint AccCarId { get; set; } = uint.MinValue;
        [ForeignKey(nameof(Manufacturer))] public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = new();
        public string Model { get; set; } = string.Empty;
        [ForeignKey(nameof(Carclass))] public int CarclassId { get; set; }
        public virtual Carclass Carclass { get; set; } = new();
        public ushort Year { get; set; } = (ushort)DateTime.UtcNow.Year;
        public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public ushort WidthMm { get; set; } = 2000;
        public ushort LengthMm { get; set; } = 5000;
        public string NameLfm { get; set; } = string.Empty;
        public string NameGoogleSheets { get; set; } = string.Empty;
    }
}
