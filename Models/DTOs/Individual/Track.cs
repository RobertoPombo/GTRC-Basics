using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class TrackFullDto : Track
    {

    }


    public class TrackUniqPropsDto0 : Mapper<Track>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class TrackUniqPropsDto1 : Mapper<Track>
    {
        [Required] public string AccTrackId { get; set; } = string.Empty;
    }


    public class TrackAddDto : Mapper<Track>
    {
        public string? Name { get; set; }
        public string? AccTrackId { get; set; }
        public byte? PitBoxesCount { get; set; }
        public byte? ServerSlotsCount { get; set; }
        public ushort? AccTimePenDtS { get; set; }
        public string? NameGoogleSheets { get; set; }
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
