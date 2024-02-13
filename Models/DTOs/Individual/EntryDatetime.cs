using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EntryDatetimeFullDto : EntryDatetime
    {

    }


    public class EntryDatetimeUniqPropsDto0 : Mapper<EntryDatetime>
    {
        [Required] public int EntryId { get; set; }
        [Required] public DateTime Date { get; set; }
    }


    public class EntryDatetimeAddDto : Mapper<EntryDatetime>
    {
        public int? EntryId { get; set; }
        public DateTime? Date { get; set; }
        public int? CarId { get; set; }
    }


    public class EntryDatetimeUpdateDto : EntryDatetimeAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EntryDatetimeFilterDto : EntryDatetimeAddDto
    {
        public int? Id { get; set; }
        public string? Entry { get; set; }
        public string? Car { get; set; }
    }


    public class EntryDatetimeFilterDtos
    {
        public EntryDatetimeFilterDto Filter { get; set; } = new();
        public EntryDatetimeFilterDto FilterMin { get; set; } = new();
        public EntryDatetimeFilterDto FilterMax { get; set; } = new();
    }
}
