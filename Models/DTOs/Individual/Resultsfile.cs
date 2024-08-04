using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class ResultsfileFullDto : Resultsfile
    {

    }


    public class ResultsfileUniqPropsDto0 : Mapper<Resultsfile>
    {
        [Required] public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required] public int ServerId { get; set; }
    }


    public class ResultsfileUniqPropsDto1 : Mapper<Resultsfile>
    {
        [Required] public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required] public int SessionId { get; set; }
    }


    public class ResultsfileAddDto : Mapper<Resultsfile>
    {
        public DateTime? Date { get; set; }
        public int? ServerId { get; set; }
        public int? SessionId { get; set; }
    }


    public class ResultsfileUpdateDto : ResultsfileAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class ResultsfileFilterDto : ResultsfileAddDto
    {
        public int? Id { get; set; }
        public string? Server { get; set; }
        public string? Session { get; set; }
    }


    public class ResultsfileFilterDtos
    {
        public ResultsfileFilterDto Filter { get; set; } = new();
        public ResultsfileFilterDto FilterMin { get; set; } = new();
        public ResultsfileFilterDto FilterMax { get; set; } = new();
    }
}
