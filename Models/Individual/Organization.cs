using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Organization : IBaseModel
    {
        public static readonly string DefaultName = nameof(Organization) + " #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
    }
}
