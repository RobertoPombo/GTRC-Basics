using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Carclass : IBaseModel
    {
        public static readonly string DefaultName = nameof(Carclass) + " #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
    }
}
