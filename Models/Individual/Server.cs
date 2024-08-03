using GTRC_Basics.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTRC_Basics.Models
{
    public class Server : IBaseModel
    {
        public static readonly ushort MaxPort = 9999;

        public override string ToString() { return "udp" + PortUdp.ToString() + "_tcp" + PortTcp.ToString() + "_" + Sim.Name.Replace(" ", ""); }

        public int Id { get; set; }
        public ushort PortUdp { get; set; }
        public ushort PortTcp { get; set; }
        [ForeignKey(nameof(Sim))] public int SimId { get; set; }
        public virtual Sim Sim { get; set; } = new();
    }
}
