using GTRC_Basics.Models;
using GTRC_Basics.Models.DTOs;

namespace GTRC_Basics
{
    public delegate void Notify();

    public static class GlobalValues
    {
        public static readonly int NoId = -1;
        public static readonly int Id0 = 1;
        public static readonly DateTime DateTimeMinValue = DateTime.MinValue.AddYears(1800);
        public static readonly DateTime DateTimeMaxValue = DateTime.MaxValue.AddDays(-1);
        public static readonly List<string> numericalTypes = ["System.Int16", "System.Int32", "System.Int64", "System.UInt16", "System.UInt32", "System.UInt64", "System.Single", "System.Double", "System.Decimal", "System.DateTime"];

        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string currentLogText = string.Empty;

        public static string BaseDirectory { get { return baseDirectory; } set { baseDirectory = value; } }
        public static string DataDirectory { get { return baseDirectory + "data\\"; } }
        public static string CurrentLogText { get { return currentLogText; } set { currentLogText = value; OnNewLogText(); } }

        public static event Notify? NewLogText;
        public static void OnNewLogText() { NewLogText?.Invoke(); }

        public static readonly List<Type> ModelTypeList = [typeof(Color), typeof(Car), typeof(Track), typeof(User), typeof(Series)];
        public static readonly Dictionary<Type, List<Type>> DictUniqPropsDtoModels = new()
        {
            { typeof(Color), [typeof(ColorUniqPropsDto0)] },
            { typeof(Car), [typeof(CarUniqPropsDto0)] },
            { typeof(Track), [typeof(TrackUniqPropsDto0)] },
            { typeof(User), [typeof(UserUniqPropsDto0), typeof(UserUniqPropsDto1)] },
            { typeof(Series), [typeof(SeriesUniqPropsDto0)] }
        };
        public static readonly Dictionary<Type, Dictionary<DtoType, Type>> DictDtoModels = new()
        {
            {
                typeof(Color), new()
                {
                    { DtoType.Add, typeof(ColorAddDto) },
                    { DtoType.Update, typeof(ColorUpdateDto) },
                    { DtoType.Filter, typeof(ColorFilterDto) },
                    { DtoType.Filters, typeof(ColorFilterDtos) },
                }
            },
            {
                typeof(Car), new()
                {
                    { DtoType.Add, typeof(CarAddDto) },
                    { DtoType.Update, typeof(CarUpdateDto) },
                    { DtoType.Filter, typeof(CarFilterDto) },
                    { DtoType.Filters, typeof(CarFilterDtos) },
                }
            },
            {
                typeof(Track), new()
                {
                    { DtoType.Add, typeof(TrackAddDto) },
                    { DtoType.Update, typeof(TrackUpdateDto) },
                    { DtoType.Filter, typeof(TrackFilterDto) },
                    { DtoType.Filters, typeof(TrackFilterDtos) },
                }
            },
            {
                typeof(User), new()
                {
                    { DtoType.Add, typeof(UserAddDto) },
                    { DtoType.Update, typeof(UserUpdateDto) },
                    { DtoType.Filter, typeof(UserFilterDto) },
                    { DtoType.Filters, typeof(UserFilterDtos) },
                }
            },
            {
                typeof(Series), new()
                {
                    { DtoType.Add, typeof(SeriesAddDto) },
                    { DtoType.Update, typeof(SeriesUpdateDto) },
                    { DtoType.Filter, typeof(SeriesFilterDto) },
                    { DtoType.Filters, typeof(SeriesFilterDtos) },
                }
            },
        };

        public static bool IsForeignId(string propertyName)
        {
            if (propertyName.Length > 2 && propertyName[^2..] == "Id")
            {
                foreach (Type type in ModelTypeList)
                {
                    if (propertyName[..^2] == type.Name) { return true; }
                }
                return false;
            }
            return false;
        }
    }
}
