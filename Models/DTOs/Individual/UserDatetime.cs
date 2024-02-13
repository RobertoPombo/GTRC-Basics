using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class UserDatetimeFullDto : UserDatetime
    {

    }


    public class UserDatetimeUniqPropsDto0 : Mapper<UserDatetime>
    {
        [Required] public int UserId { get; set; }
        [Required] public DateTime Date { get; set; }
    }


    public class UserDatetimeAddDto : Mapper<UserDatetime>
    {
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public short? EloRating { get; set; }
        public short? SafetyRating { get; set; }
        public byte? Warnings { get; set; }
    }


    public class UserDatetimeUpdateDto : UserDatetimeAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class UserDatetimeFilterDto : UserDatetimeAddDto
    {
        public int? Id { get; set; }
        public string? User { get; set; }
    }


    public class UserDatetimeFilterDtos
    {
        public UserDatetimeFilterDto Filter { get; set; } = new();
        public UserDatetimeFilterDto FilterMin { get; set; } = new();
        public UserDatetimeFilterDto FilterMax { get; set; } = new();
    }
}
