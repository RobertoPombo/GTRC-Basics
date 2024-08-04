using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Lap : IBaseModel
    {
        public static readonly ushort MinSessionLapNr = 1;

        public override string ToString() { return RaceNumber.ToString() + " - " + Scripts.Ms2Laptime(TimeMs).ToString() + " - " + Resultsfile.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Resultsfile))] public int ResultsfileId { get; set; }
        public virtual Resultsfile Resultsfile { get; set; } = new();
        public ushort SessionLapNr { get; set; } = MinSessionLapNr;
        public bool IsValid { get; set; } = false;
        public uint TimeMs { get; set; } = uint.MaxValue;
        public uint Sector1Ms { get; set; } = uint.MaxValue;
        public uint Sector2Ms { get; set; } = uint.MaxValue;
        public uint Sector3Ms { get; set; } = uint.MaxValue;
        public ushort RaceNumber { get; set; } = Entry.DefaultRaceNumber;
        public ulong SteamId { get; set; } = GlobalValues.NoSteamId;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public uint AccCarId { get; set; } = uint.MinValue;
        public short BallastKg { get; set; }
        public short Restrictor { get; set; }
        public AccCupCategory AccCupCategory { get; set; } = AccCupCategory.Overall;
    }
}
