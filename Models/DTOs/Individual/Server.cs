using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class ServerFullDto : Server
    {

    }


    public class ServerUniqPropsDto0 : Mapper<Server>
    {
        [Required] public ushort PortUdp { get; set; } = ushort.MinValue;
    }


    public class ServerUniqPropsDto1 : Mapper<Server>
    {
        [Required] public ushort PortTcp { get; set; } = ushort.MinValue;
    }


    public class ServerAddDto : Mapper<Server>
    {
        public ushort? PortUdp { get; set; }
        public ushort? PortTcp { get; set; }
        public int? SimId { get; set; }
    }


    public class ServerUpdateDto : ServerAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class ServerFilterDto : ServerAddDto
    {
        public int? Id { get; set; }
        public string? Sim { get; set; }
    }


    public class ServerFilterDtos
    {
        public ServerFilterDto Filter { get; set; } = new();
        public ServerFilterDto FilterMin { get; set; } = new();
        public ServerFilterDto FilterMax { get; set; } = new();
    }
}
