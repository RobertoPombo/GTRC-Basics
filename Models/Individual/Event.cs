using System.ComponentModel.DataAnnotations.Schema;

using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Event : IBaseModel
    {
        public static readonly string DefaultName = nameof(Event);
        public static readonly short DefaultAmbientTemp = 20;
        public static readonly byte MaxCloudLevel = 100;
        public static readonly byte MaxRainLevel = 100;
        public static readonly byte MaxWeatherRandomness = 7;

        public override string ToString() { return Name + " - " + Season.ToString(); }

        public int Id { get; set; }
        [ForeignKey(nameof(Season))] public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = new();
        public string Name { get; set; } = DefaultName;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Track))] public int TrackId { get; set; }
        public virtual Track Track { get; set; } = new();
        public short AmbientTemp { get; set; } = DefaultAmbientTemp;
        public byte CloudLevel { get; set; } = byte.MinValue;
        public byte RainLevel { get; set; } = byte.MinValue;
        public byte WeatherRandomness { get; set; } = byte.MinValue;
        public bool FixedConditions { get; set; } = false;
    }
}
