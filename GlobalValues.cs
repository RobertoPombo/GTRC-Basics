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
        public static readonly DateTime DateTimeMinValue = new(1000, DateTime.MinValue.Month, DateTime.MinValue.Day, 0, 0, 0, 0, DateTime.MinValue.Kind);
        public static readonly DateTime DateTimeMaxValue = new(DateTime.MaxValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, 0, 0, 0, 0, DateTime.MaxValue.Kind);
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

        public static readonly List<Type> ModelTypeList = [
            typeof(Color),
            typeof(Sim),
            typeof(User),
            typeof(Track),
            typeof(Carclass),
            typeof(Manufacturer),
            typeof(Car),
            typeof(Role),
            typeof(UserRole),
            typeof(UserDatetime),
            typeof(Bop),
            typeof(BopTrackCar),
            typeof(Series),
            typeof(Season),
            typeof(SeasonCarclass),
            typeof(Organization),
            typeof(OrganizationUser),
            typeof(Team),
            typeof(Entry),
            typeof(EntryDatetime),
            typeof(Event),
            typeof(EventCarclass),
            typeof(EventCar),
            typeof(EntryEvent),
            typeof(EntryUserEvent),
            typeof(Pointssystem),
            typeof(PointssystemPosition),
            typeof(StintAnalysisMethod),
            typeof(Server),
            typeof(Session),
            typeof(Resultsfile),
            typeof(Lap),
            typeof(Leaderboardline),
            typeof(Incident),
            typeof(IncidentEntry)];

        public static readonly Dictionary<Type, string> SqlTableNames = new()
        {
            { typeof(Color), "Colors" },
            { typeof(Sim), "Simulations" },
            { typeof(User), "Users" },
            { typeof(Track), "Tracks" },
            { typeof(Carclass), "Carclasses" },
            { typeof(Manufacturer), "Manufacturers" },
            { typeof(Car), "Cars" },
            { typeof(Role), "Roles" },
            { typeof(UserRole), "UsersRoles" },
            { typeof(UserDatetime), "UsersDatetimes" },
            { typeof(Bop), "Bops" },
            { typeof(BopTrackCar), "BopsTracksCars" },
            { typeof(Series), "Series" },
            { typeof(Season), "Seasons" },
            { typeof(SeasonCarclass), "SeasonsCarclasses" },
            { typeof(Organization), "Organizations" },
            { typeof(OrganizationUser), "OrganizationsUsers" },
            { typeof(Team), "Teams" },
            { typeof(Entry), "Entries" },
            { typeof(EntryDatetime), "EntriesDatetimes" },
            { typeof(Event), "Events" },
            { typeof(EventCarclass), "EventsCarclasses" },
            { typeof(EventCar), "EventsCars" },
            { typeof(EntryEvent), "EntriesEvents" },
            { typeof(EntryUserEvent), "EntriesUsersEvents" },
            { typeof(Pointssystem), "Pointssystems" },
            { typeof(PointssystemPosition), "PointssystemsPositions" },
            { typeof(StintAnalysisMethod), "StintAnalysisMethods" },
            { typeof(Server), "Servers" },
            { typeof(Session), "Sessions" },
            { typeof(Resultsfile), "Resultsfiles" },
            { typeof(Lap), "Laps" },
            { typeof(Leaderboardline), "Leaderboardlines" },
            { typeof(Incident), "Incidents" },
            { typeof(IncidentEntry), "IncidentsEntries" }
        };

        public static readonly Dictionary<Type, List<Type>> DictUniqPropsDtoModels = new()
        {
            { typeof(Color), [typeof(ColorUniqPropsDto0)] },
            { typeof(Sim), [typeof(SimUniqPropsDto0), typeof(SimUniqPropsDto1)] },
            { typeof(User), [typeof(UserUniqPropsDto0), typeof(UserUniqPropsDto1)] },
            { typeof(Track), [typeof(TrackUniqPropsDto0), typeof(TrackUniqPropsDto1), typeof(TrackUniqPropsDto2), typeof(TrackUniqPropsDto3)] },
            { typeof(Carclass), [typeof(CarclassUniqPropsDto0)] },
            { typeof(Manufacturer), [typeof(ManufacturerUniqPropsDto0)] },
            { typeof(Car), [typeof(CarUniqPropsDto0), typeof(CarUniqPropsDto1), typeof(CarUniqPropsDto2), typeof(CarUniqPropsDto3)] },
            { typeof(Role), [typeof(RoleUniqPropsDto0)] },
            { typeof(UserRole), [typeof(UserRoleUniqPropsDto0)] },
            { typeof(UserDatetime), [typeof(UserDatetimeUniqPropsDto0)] },
            { typeof(Bop), [typeof(BopUniqPropsDto0)] },
            { typeof(BopTrackCar), [typeof(BopTrackCarUniqPropsDto0)] },
            { typeof(Series), [typeof(SeriesUniqPropsDto0), typeof(SeriesUniqPropsDto1), typeof(SeriesUniqPropsDto2), typeof(SeriesUniqPropsDto3), typeof(SeriesUniqPropsDto4)] },
            { typeof(Season), [typeof(SeasonUniqPropsDto0)] },
            { typeof(SeasonCarclass), [typeof(SeasonCarclassUniqPropsDto0)] },
            { typeof(Organization), [typeof(OrganizationUniqPropsDto0)] },
            { typeof(OrganizationUser), [typeof(OrganizationUserUniqPropsDto0)] },
            { typeof(Team), [typeof(TeamUniqPropsDto0)] },
            { typeof(Entry), [typeof(EntryUniqPropsDto0)] },
            { typeof(EntryDatetime), [typeof(EntryDatetimeUniqPropsDto0)] },
            { typeof(Event), [typeof(EventUniqPropsDto0), typeof(EventUniqPropsDto1)] },
            { typeof(EventCarclass), [typeof(EventCarclassUniqPropsDto0)] },
            { typeof(EventCar), [typeof(EventCarUniqPropsDto0)] },
            { typeof(EntryEvent), [typeof(EntryEventUniqPropsDto0)] },
            { typeof(EntryUserEvent), [typeof(EntryUserEventUniqPropsDto0)] },
            { typeof(Pointssystem), [typeof(PointssystemUniqPropsDto0)] },
            { typeof(PointssystemPosition), [typeof(PointssystemPositionUniqPropsDto0)] },
            { typeof(StintAnalysisMethod), [typeof(StintAnalysisMethodUniqPropsDto0)] },
            { typeof(Server), [typeof(ServerUniqPropsDto0), typeof(ServerUniqPropsDto1)] },
            { typeof(Session), [typeof(SessionUniqPropsDto0)] },
            { typeof(Resultsfile), [typeof(ResultsfileUniqPropsDto0), typeof(ResultsfileUniqPropsDto1)] },
            { typeof(Lap), [typeof(LapUniqPropsDto0)] },
            { typeof(Leaderboardline), [typeof(LeaderboardlineUniqPropsDto0)] },
            { typeof(Incident), [typeof(IncidentUniqPropsDto0)] },
            { typeof(IncidentEntry), [typeof(IncidentEntryUniqPropsDto0)] }
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
                    { DtoType.Filters, typeof(ColorFilterDtos) }
                }
            },
            {
                typeof(Sim), new()
                {
                    { DtoType.Full, typeof(SimFullDto) },
                    { DtoType.Add, typeof(SimAddDto) },
                    { DtoType.Update, typeof(SimUpdateDto) },
                    { DtoType.Filter, typeof(SimFilterDto) },
                    { DtoType.Filters, typeof(SimFilterDtos) }
                }
            },
            {
                typeof(User), new()
                {
                    { DtoType.Full, typeof(UserFullDto) },
                    { DtoType.Add, typeof(UserAddDto) },
                    { DtoType.Update, typeof(UserUpdateDto) },
                    { DtoType.Filter, typeof(UserFilterDto) },
                    { DtoType.Filters, typeof(UserFilterDtos) }
                }
            },
            {
                typeof(Track), new()
                {
                    { DtoType.Full, typeof(TrackFullDto) },
                    { DtoType.Add, typeof(TrackAddDto) },
                    { DtoType.Update, typeof(TrackUpdateDto) },
                    { DtoType.Filter, typeof(TrackFilterDto) },
                    { DtoType.Filters, typeof(TrackFilterDtos) }
                }
            },
            {
                typeof(Carclass), new()
                {
                    { DtoType.Full, typeof(CarclassFullDto) },
                    { DtoType.Add, typeof(CarclassAddDto) },
                    { DtoType.Update, typeof(CarclassUpdateDto) },
                    { DtoType.Filter, typeof(CarclassFilterDto) },
                    { DtoType.Filters, typeof(CarclassFilterDtos) }
                }
            },
            {
                typeof(Manufacturer), new()
                {
                    { DtoType.Full, typeof(ManufacturerFullDto) },
                    { DtoType.Add, typeof(ManufacturerAddDto) },
                    { DtoType.Update, typeof(ManufacturerUpdateDto) },
                    { DtoType.Filter, typeof(ManufacturerFilterDto) },
                    { DtoType.Filters, typeof(ManufacturerFilterDtos) }
                }
            },
            {
                typeof(Car), new()
                {
                    { DtoType.Full, typeof(CarFullDto) },
                    { DtoType.Add, typeof(CarAddDto) },
                    { DtoType.Update, typeof(CarUpdateDto) },
                    { DtoType.Filter, typeof(CarFilterDto) },
                    { DtoType.Filters, typeof(CarFilterDtos) }
                }
            },
            {
                typeof(Role), new()
                {
                    { DtoType.Full, typeof(RoleFullDto) },
                    { DtoType.Add, typeof(RoleAddDto) },
                    { DtoType.Update, typeof(RoleUpdateDto) },
                    { DtoType.Filter, typeof(RoleFilterDto) },
                    { DtoType.Filters, typeof(RoleFilterDtos) }
                }
            },
            {
                typeof(UserRole), new()
                {
                    { DtoType.Full, typeof(UserRoleFullDto) },
                    { DtoType.Add, typeof(UserRoleAddDto) },
                    { DtoType.Update, typeof(UserRoleUpdateDto) },
                    { DtoType.Filter, typeof(UserRoleFilterDto) },
                    { DtoType.Filters, typeof(UserRoleFilterDtos) }
                }
            },
            {
                typeof(UserDatetime), new()
                {
                    { DtoType.Full, typeof(UserDatetimeFullDto) },
                    { DtoType.Add, typeof(UserDatetimeAddDto) },
                    { DtoType.Update, typeof(UserDatetimeUpdateDto) },
                    { DtoType.Filter, typeof(UserDatetimeFilterDto) },
                    { DtoType.Filters, typeof(UserDatetimeFilterDtos) }
                }
            },
            {
                typeof(Bop), new()
                {
                    { DtoType.Full, typeof(BopFullDto) },
                    { DtoType.Add, typeof(BopAddDto) },
                    { DtoType.Update, typeof(BopUpdateDto) },
                    { DtoType.Filter, typeof(BopFilterDto) },
                    { DtoType.Filters, typeof(BopFilterDtos) }
                }
            },
            {
                typeof(BopTrackCar), new()
                {
                    { DtoType.Full, typeof(BopTrackCarFullDto) },
                    { DtoType.Add, typeof(BopTrackCarAddDto) },
                    { DtoType.Update, typeof(BopTrackCarUpdateDto) },
                    { DtoType.Filter, typeof(BopTrackCarFilterDto) },
                    { DtoType.Filters, typeof(BopTrackCarFilterDtos) }
                }
            },
            {
                typeof(Series), new()
                {
                    { DtoType.Full, typeof(SeriesFullDto) },
                    { DtoType.Add, typeof(SeriesAddDto) },
                    { DtoType.Update, typeof(SeriesUpdateDto) },
                    { DtoType.Filter, typeof(SeriesFilterDto) },
                    { DtoType.Filters, typeof(SeriesFilterDtos) }
                }
            },
            {
                typeof(Season), new()
                {
                    { DtoType.Full, typeof(SeasonFullDto) },
                    { DtoType.Add, typeof(SeasonAddDto) },
                    { DtoType.Update, typeof(SeasonUpdateDto) },
                    { DtoType.Filter, typeof(SeasonFilterDto) },
                    { DtoType.Filters, typeof(SeasonFilterDtos) }
                }
            },
            {
                typeof(SeasonCarclass), new()
                {
                    { DtoType.Full, typeof(SeasonCarclassFullDto) },
                    { DtoType.Add, typeof(SeasonCarclassAddDto) },
                    { DtoType.Update, typeof(SeasonCarclassUpdateDto) },
                    { DtoType.Filter, typeof(SeasonCarclassFilterDto) },
                    { DtoType.Filters, typeof(SeasonCarclassFilterDtos) }
                }
            },
            {
                typeof(Organization), new()
                {
                    { DtoType.Full, typeof(OrganizationFullDto) },
                    { DtoType.Add, typeof(OrganizationAddDto) },
                    { DtoType.Update, typeof(OrganizationUpdateDto) },
                    { DtoType.Filter, typeof(OrganizationFilterDto) },
                    { DtoType.Filters, typeof(OrganizationFilterDtos) }
                }
            },
            {
                typeof(OrganizationUser), new()
                {
                    { DtoType.Full, typeof(OrganizationUserFullDto) },
                    { DtoType.Add, typeof(OrganizationUserAddDto) },
                    { DtoType.Update, typeof(OrganizationUserUpdateDto) },
                    { DtoType.Filter, typeof(OrganizationUserFilterDto) },
                    { DtoType.Filters, typeof(OrganizationUserFilterDtos) }
                }
            },
            {
                typeof(Team), new()
                {
                    { DtoType.Full, typeof(TeamFullDto) },
                    { DtoType.Add, typeof(TeamAddDto) },
                    { DtoType.Update, typeof(TeamUpdateDto) },
                    { DtoType.Filter, typeof(TeamFilterDto) },
                    { DtoType.Filters, typeof(TeamFilterDtos) }
                }
            },
            {
                typeof(Entry), new()
                {
                    { DtoType.Full, typeof(EntryFullDto) },
                    { DtoType.Add, typeof(EntryAddDto) },
                    { DtoType.Update, typeof(EntryUpdateDto) },
                    { DtoType.Filter, typeof(EntryFilterDto) },
                    { DtoType.Filters, typeof(EntryFilterDtos) }
                }
            },
            {
                typeof(EntryDatetime), new()
                {
                    { DtoType.Full, typeof(EntryDatetimeFullDto) },
                    { DtoType.Add, typeof(EntryDatetimeAddDto) },
                    { DtoType.Update, typeof(EntryDatetimeUpdateDto) },
                    { DtoType.Filter, typeof(EntryDatetimeFilterDto) },
                    { DtoType.Filters, typeof(EntryDatetimeFilterDtos) }
                }
            },
            {
                typeof(Event), new()
                {
                    { DtoType.Full, typeof(EventFullDto) },
                    { DtoType.Add, typeof(EventAddDto) },
                    { DtoType.Update, typeof(EventUpdateDto) },
                    { DtoType.Filter, typeof(EventFilterDto) },
                    { DtoType.Filters, typeof(EventFilterDtos) }
                }
            },
            {
                typeof(EventCarclass), new()
                {
                    { DtoType.Full, typeof(EventCarclassFullDto) },
                    { DtoType.Add, typeof(EventCarclassAddDto) },
                    { DtoType.Update, typeof(EventCarclassUpdateDto) },
                    { DtoType.Filter, typeof(EventCarclassFilterDto) },
                    { DtoType.Filters, typeof(EventCarclassFilterDtos) }
                }
            },
            {
                typeof(EventCar), new()
                {
                    { DtoType.Full, typeof(EventCarFullDto) },
                    { DtoType.Add, typeof(EventCarAddDto) },
                    { DtoType.Update, typeof(EventCarUpdateDto) },
                    { DtoType.Filter, typeof(EventCarFilterDto) },
                    { DtoType.Filters, typeof(EventCarFilterDtos) }
                }
            },
            {
                typeof(EntryEvent), new()
                {
                    { DtoType.Full, typeof(EntryEventFullDto) },
                    { DtoType.Add, typeof(EntryEventAddDto) },
                    { DtoType.Update, typeof(EntryEventUpdateDto) },
                    { DtoType.Filter, typeof(EntryEventFilterDto) },
                    { DtoType.Filters, typeof(EntryEventFilterDtos) }
                }
            },
            {
                typeof(EntryUserEvent), new()
                {
                    { DtoType.Full, typeof(EntryUserEventFullDto) },
                    { DtoType.Add, typeof(EntryUserEventAddDto) },
                    { DtoType.Update, typeof(EntryUserEventUpdateDto) },
                    { DtoType.Filter, typeof(EntryUserEventFilterDto) },
                    { DtoType.Filters, typeof(EntryUserEventFilterDtos) }
                }
            },
            {
                typeof(Pointssystem), new()
                {
                    { DtoType.Full, typeof(PointssystemFullDto) },
                    { DtoType.Add, typeof(PointssystemAddDto) },
                    { DtoType.Update, typeof(PointssystemUpdateDto) },
                    { DtoType.Filter, typeof(PointssystemFilterDto) },
                    { DtoType.Filters, typeof(PointssystemFilterDtos) }
                }
            },
            {
                typeof(PointssystemPosition), new()
                {
                    { DtoType.Full, typeof(PointssystemPositionFullDto) },
                    { DtoType.Add, typeof(PointssystemPositionAddDto) },
                    { DtoType.Update, typeof(PointssystemPositionUpdateDto) },
                    { DtoType.Filter, typeof(PointssystemPositionFilterDto) },
                    { DtoType.Filters, typeof(PointssystemPositionFilterDtos) }
                }
            },
            {
                typeof(StintAnalysisMethod), new()
                {
                    { DtoType.Full, typeof(StintAnalysisMethodFullDto) },
                    { DtoType.Add, typeof(StintAnalysisMethodAddDto) },
                    { DtoType.Update, typeof(StintAnalysisMethodUpdateDto) },
                    { DtoType.Filter, typeof(StintAnalysisMethodFilterDto) },
                    { DtoType.Filters, typeof(StintAnalysisMethodFilterDtos) }
                }
            },
            {
                typeof(Server), new()
                {
                    { DtoType.Full, typeof(ServerFullDto) },
                    { DtoType.Add, typeof(ServerAddDto) },
                    { DtoType.Update, typeof(ServerUpdateDto) },
                    { DtoType.Filter, typeof(ServerFilterDto) },
                    { DtoType.Filters, typeof(ServerFilterDtos) }
                }
            },
            {
                typeof(Session), new()
                {
                    { DtoType.Full, typeof(SessionFullDto) },
                    { DtoType.Add, typeof(SessionAddDto) },
                    { DtoType.Update, typeof(SessionUpdateDto) },
                    { DtoType.Filter, typeof(SessionFilterDto) },
                    { DtoType.Filters, typeof(SessionFilterDtos) }
                }
            },
            {
                typeof(Resultsfile), new()
                {
                    { DtoType.Full, typeof(ResultsfileFullDto) },
                    { DtoType.Add, typeof(ResultsfileAddDto) },
                    { DtoType.Update, typeof(ResultsfileUpdateDto) },
                    { DtoType.Filter, typeof(ResultsfileFilterDto) },
                    { DtoType.Filters, typeof(ResultsfileFilterDtos) }
                }
            },
            {
                typeof(Lap), new()
                {
                    { DtoType.Full, typeof(LapFullDto) },
                    { DtoType.Add, typeof(LapAddDto) },
                    { DtoType.Update, typeof(LapUpdateDto) },
                    { DtoType.Filter, typeof(LapFilterDto) },
                    { DtoType.Filters, typeof(LapFilterDtos) }
                }
            },
            {
                typeof(Leaderboardline), new()
                {
                    { DtoType.Full, typeof(LeaderboardlineFullDto) },
                    { DtoType.Add, typeof(LeaderboardlineAddDto) },
                    { DtoType.Update, typeof(LeaderboardlineUpdateDto) },
                    { DtoType.Filter, typeof(LeaderboardlineFilterDto) },
                    { DtoType.Filters, typeof(LeaderboardlineFilterDtos) }
                }
            },
            {
                typeof(Incident), new()
                {
                    { DtoType.Full, typeof(IncidentFullDto) },
                    { DtoType.Add, typeof(IncidentAddDto) },
                    { DtoType.Update, typeof(IncidentUpdateDto) },
                    { DtoType.Filter, typeof(IncidentFilterDto) },
                    { DtoType.Filters, typeof(IncidentFilterDtos) }
                }
            },
            {
                typeof(IncidentEntry), new()
                {
                    { DtoType.Full, typeof(IncidentEntryFullDto) },
                    { DtoType.Add, typeof(IncidentEntryAddDto) },
                    { DtoType.Update, typeof(IncidentEntryUpdateDto) },
                    { DtoType.Filter, typeof(IncidentEntryFilterDto) },
                    { DtoType.Filters, typeof(IncidentEntryFilterDtos) }
                }
            }
            /*
            {
                typeof(), new()
                {
                    { DtoType.Full, typeof(FullDto) },
                    { DtoType.Add, typeof(AddDto) },
                    { DtoType.Update, typeof(UpdateDto) },
                    { DtoType.Filter, typeof(FilterDto) },
                    { DtoType.Filters, typeof(FilterDtos) }
                }
            },
            */
        };
    }
}
