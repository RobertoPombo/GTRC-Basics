using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class LeaderboardlineFullDto : Leaderboardline
    {

    }


    public class LeaderboardlineUniqPropsDto0 : Mapper<Leaderboardline>
    {
        [Required] public int SessionId { get; set; }
        [Required] public int EntryId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public int CarId { get; set; }
    }


    public class LeaderboardlineAddDto : Mapper<Leaderboardline>
    {
        public int? SessionId { get; set; }
        public int? EntryId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public ushort? LapsCount { get; set; }
        public uint? TotalTimeMs { get; set; }
        public uint? BestLapMs { get; set; }
        public uint? StintAverageMs { get; set; }
        public uint? BestSector1Ms { get; set; }
        public uint? BestSector2Ms { get; set; }
        public uint? BestSector3Ms { get; set; }
        public ushort? ValidLapsCount { get; set; }
        public ushort? ValidStintsCount { get; set; }
    }


    public class LeaderboardlineUpdateDto : LeaderboardlineAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class LeaderboardlineFilterDto : LeaderboardlineAddDto
    {
        public int? Id { get; set; }
        public string? Session { get; set; }
        public string? Entry { get; set; }
        public string? User { get; set; }
        public string? Car { get; set; }
    }


    public class LeaderboardlineFilterDtos
    {
        public LeaderboardlineFilterDto Filter { get; set; } = new();
        public LeaderboardlineFilterDto FilterMin { get; set; } = new();
        public LeaderboardlineFilterDto FilterMax { get; set; } = new();
    }
}
