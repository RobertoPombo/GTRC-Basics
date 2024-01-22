using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EntryFullDto : Entry
    {

    }


    public class EntryUniqPropsDto0 : Mapper<Entry>
    {
        [Required] public int SeasonId { get; set; }
        [Required] public ushort RaceNumber { get; set; }
    }


    public class EntryAddDto : Mapper<Entry>
    {
        public int? SeasonId { get; set; }
        public ushort? RaceNumber { get; set; }
        public int? TeamId { get; set; }
        public int? CarId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? SignOutDate { get; set; }
        public short? BallastKg { get; set; }
        public short? Restrictor { get; set; }
        public AccDriverCategory? AccDriverCategory { get; set; }
        public bool? ScorePoints { get; set; }
        public bool? IsPermanent { get; set; }
    }


    public class EntryUpdateDto : EntryAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EntryFilterDto : EntryAddDto
    {
        public int? Id { get; set; }
        public string? Season { get; set; }
        public string? Team { get; set; }
    }


    public class EntryFilterDtos
    {
        public EntryFilterDto Filter { get; set; } = new();
        public EntryFilterDto FilterMin { get; set; } = new();
        public EntryFilterDto FilterMax { get; set; } = new();
    }
}
