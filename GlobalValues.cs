using GTRC_Basics.Models;
using GTRC_Basics.Models.DTOs;

namespace GTRC_Basics
{
    public delegate void Notify();

    public static class GlobalValues
    {
        public static readonly string Id = "Id";
        public static readonly int NoId = 0;
        public static readonly int Id0 = 1;
        public static readonly DateTime DateTimeMinValue = DateTime.MinValue.AddYears(1800);
        public static readonly DateTime DateTimeMaxValue = DateTime.MaxValue.AddDays(-1);
        public static readonly ulong NoSteamId = (ulong)NoId;
        public static readonly ulong MinSteamId = (ulong)Math.Pow(10, 16);
        public static readonly ulong MaxSteamId = MinSteamId * 10 - 1;
        public static readonly ulong NoDiscordId = (ulong)NoId;
        public static readonly ulong MinDiscordId = (ulong)Math.Pow(10, 17);
        public static readonly ulong MaxDiscordId = ulong.MaxValue;
        public static readonly List<Type> numericalTypes = [
            typeof(byte), typeof(byte?), typeof(short), typeof(short?), typeof(ushort), typeof(ushort?), typeof(int), typeof(int?), typeof(uint), typeof(uint?),
            typeof(long), typeof(long?), typeof(ulong), typeof(ulong?), typeof(float), typeof(float?), typeof(double), typeof(double?), typeof(decimal), typeof(decimal?),
            typeof(DateTime), typeof(DateTime?), typeof(DateOnly), typeof(DateOnly?), typeof(TimeSpan), typeof(TimeSpan?)
            ];

        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string currentLogText = string.Empty;

        public static string BaseDirectory { get { return baseDirectory; } set { baseDirectory = value; } }
        public static string DataDirectory { get { return baseDirectory + "data\\"; } }
        public static string CurrentLogText { get { return currentLogText; } set { currentLogText = value; OnNewLogText(); } }

        public static event Notify? NewLogText;
        public static void OnNewLogText() { NewLogText?.Invoke(); }

        public static readonly List<Type> ModelTypeList = [typeof(Color), typeof(Manufacturer), typeof(Car), typeof(Track), typeof(User), typeof(Series), typeof(Season)];
        public static readonly Dictionary<Type, string> SqlTableNames = new()
        {
            { typeof(Color), "Colors" },
            { typeof(Manufacturer), "Manufacturers" },
            { typeof(Car), "Cars" },
            { typeof(Track), "Tracks" },
            { typeof(User), "Users" },
            { typeof(Series), "Series" },
            { typeof(Season), "Seasons" }
        };
        public static readonly Dictionary<Type, List<Type>> DictUniqPropsDtoModels = new()
        {
            { typeof(Color), [typeof(ColorUniqPropsDto0)] },
            { typeof(Manufacturer), [typeof(ManufacturerUniqPropsDto0)] },
            { typeof(Car), [typeof(CarUniqPropsDto0), typeof(CarUniqPropsDto1)] },
            { typeof(Track), [typeof(TrackUniqPropsDto0), typeof(TrackUniqPropsDto1)] },
            { typeof(User), [typeof(UserUniqPropsDto0), typeof(UserUniqPropsDto1)] },
            { typeof(Series), [typeof(SeriesUniqPropsDto0)] },
            { typeof(Season), [typeof(SeasonUniqPropsDto0)] }
        };
        public static readonly Dictionary<Type, Dictionary<DtoType, Type>> DictDtoModels = new()
        {
            {
                typeof(Color), new()
                {
                    { DtoType.Full, typeof(ColorFullDto) },
                    { DtoType.Add, typeof(ColorAddDto) },
                    { DtoType.Update, typeof(ColorUpdateDto) },
                    { DtoType.Filter, typeof(ColorFilterDto) },
                    { DtoType.Filters, typeof(ColorFilterDtos) },
                }
            },
            {
                typeof(Manufacturer), new()
                {
                    { DtoType.Full, typeof(ManufacturerFullDto) },
                    { DtoType.Add, typeof(ManufacturerAddDto) },
                    { DtoType.Update, typeof(ManufacturerUpdateDto) },
                    { DtoType.Filter, typeof(ManufacturerFilterDto) },
                    { DtoType.Filters, typeof(ManufacturerFilterDtos) },
                }
            },
            {
                typeof(Car), new()
                {
                    { DtoType.Full, typeof(CarFullDto) },
                    { DtoType.Add, typeof(CarAddDto) },
                    { DtoType.Update, typeof(CarUpdateDto) },
                    { DtoType.Filter, typeof(CarFilterDto) },
                    { DtoType.Filters, typeof(CarFilterDtos) },
                }
            },
            {
                typeof(Track), new()
                {
                    { DtoType.Full, typeof(TrackFullDto) },
                    { DtoType.Add, typeof(TrackAddDto) },
                    { DtoType.Update, typeof(TrackUpdateDto) },
                    { DtoType.Filter, typeof(TrackFilterDto) },
                    { DtoType.Filters, typeof(TrackFilterDtos) },
                }
            },
            {
                typeof(User), new()
                {
                    { DtoType.Full, typeof(UserFullDto) },
                    { DtoType.Add, typeof(UserAddDto) },
                    { DtoType.Update, typeof(UserUpdateDto) },
                    { DtoType.Filter, typeof(UserFilterDto) },
                    { DtoType.Filters, typeof(UserFilterDtos) },
                }
            },
            {
                typeof(Series), new()
                {
                    { DtoType.Full, typeof(SeriesFullDto) },
                    { DtoType.Add, typeof(SeriesAddDto) },
                    { DtoType.Update, typeof(SeriesUpdateDto) },
                    { DtoType.Filter, typeof(SeriesFilterDto) },
                    { DtoType.Filters, typeof(SeriesFilterDtos) },
                }
            },
            {
                typeof(Season), new()
                {
                    { DtoType.Full, typeof(SeasonFullDto) },
                    { DtoType.Add, typeof(SeasonAddDto) },
                    { DtoType.Update, typeof(SeasonUpdateDto) },
                    { DtoType.Filter, typeof(SeasonFilterDto) },
                    { DtoType.Filters, typeof(SeasonFilterDtos) },
                }
            }
        };

        public static bool IsForeignId(string propertyName)
        {
            if (GetTypeForeignId(propertyName) is null) { return false; }
            else { return true; }
        }

        public static Type? GetTypeForeignId(string propertyName)
        {
            if (propertyName.Length > Id.Length && propertyName[^Id.Length..] == Id)
            {
                foreach (Type type in ModelTypeList)
                {
                    if (propertyName[..^Id.Length] == type.Name) { return type; }
                }
                return null;
            }
            return null;
        }
    }
}
