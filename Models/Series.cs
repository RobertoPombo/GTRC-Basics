using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Series : IBaseModel
    {
        public static readonly string DefaultName = "Series #1";

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
    }
}
