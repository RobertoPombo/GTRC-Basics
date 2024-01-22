using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Role : IBaseModel
    {
        public static readonly string DefaultName = nameof(Role) + " #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public ulong DiscordId { get; set; } = GlobalValues.NoDiscordId;
    }
}
