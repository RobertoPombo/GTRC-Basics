using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class BopTrackCarFullDto : BopTrackCar
    {

    }


    public class BopTrackCarUniqPropsDto0 : Mapper<BopTrackCar>
    {
        [Required] public int BopId { get; set; }
        [Required] public int TrackId { get; set; }
        [Required] public int CarId { get; set; }
    }


    public class BopTrackCarAddDto : Mapper<BopTrackCar>
    {
        public int? BopId { get; set; }
        public int? TrackId { get; set; }
        public int? CarId { get; set; }
        public short? BallastKg { get; set; }
        public short? Restrictor { get; set; }
    }


    public class BopTrackCarUpdateDto : BopTrackCarAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class BopTrackCarFilterDto : BopTrackCarAddDto
    {
        public int? Id { get; set; }
        public string? Bop { get; set; }
        public string? Track { get; set; }
        public string? Car { get; set; }
    }


    public class BopTrackCarFilterDtos
    {
        public BopTrackCarFilterDto Filter { get; set; } = new();
        public BopTrackCarFilterDto FilterMin { get; set; } = new();
        public BopTrackCarFilterDto FilterMax { get; set; } = new();
    }
}
