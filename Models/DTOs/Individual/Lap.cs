using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class LapFullDto : Lap
    {

    }


    public class LapAddDto : Mapper<Lap>
    {
        public int? ResultsfileId { get; set; }
        public bool? IsValid { get; set; }
        public uint? TimeMs { get; set; }
        public uint? Sector1Ms { get; set; }
        public uint? Sector2Ms { get; set; }
        public uint? Sector3Ms { get; set; }
        public ushort? RaceNumber { get; set; }
        public ulong? SteamId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public uint? AccCarId { get; set; }
        public short? BallastKg { get; set; }
        public short? Restrictor { get; set; }
        public AccCupCategory? AccCupCategory { get; set; }
    }


    public class LapUpdateDto : LapAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class LapFilterDto : LapAddDto
    {
        public int? Id { get; set; }
        public string? Resultsfile { get; set; }
    }


    public class LapFilterDtos
    {
        public LapFilterDto Filter { get; set; } = new();
        public LapFilterDto FilterMin { get; set; } = new();
        public LapFilterDto FilterMax { get; set; } = new();
    }
}
