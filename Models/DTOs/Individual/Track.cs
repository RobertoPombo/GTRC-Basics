using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class TrackFullDto : Track
    {

    }


    public class TrackUniqPropsDto0 : Mapper<Track>
    {
        [Required] public string AccTrackId { get; set; } = string.Empty;
    }


    public class TrackAddDto : Mapper<Track>
    {
        public string? AccTrackId { get; set; }
        public string? Name { get; set; }
        public ushort? PitBoxesCount { get; set; }
        public ushort? ServerSlotsCount { get; set; }
        public ushort? AccTimePenDtS { get; set; }
        public string? NameGtrc { get; set; }
    }


    public class TrackUpdateDto : TrackAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class TrackFilterDto : TrackAddDto
    {
        public int? Id { get; set; }
    }


    public class TrackFilterDtos
    {
        public TrackFilterDto Filter { get; set; } = new();
        public TrackFilterDto FilterMin { get; set; } = new();
        public TrackFilterDto FilterMax { get; set; } = new();
    }
}
