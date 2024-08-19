namespace GTRC_Basics
{
    public enum TimeUnit
    {
        Miliseconds = 0,
        Seconds = 1,
        Minutes = 2,
        Hours = 3,
        Days = 4,
        Weeks = 5,
        Months = 6,
        Years = 7
    }

    public enum SessionType
    {
        Practice = 0,
        Qualifying = 1,
        Race = 2
    }

    public enum EntrylistType
    {
        None = 0,
        RaceControl = 1,
        AllDrivers = 2,
        Season = 3
    }

    public enum IncidentStatus
    {
        Open = 0,
        DoneLive = 1,
        DonePostRace = 2,
        Discarded = 3
    }

    public enum ReportReason
    {
        ManualReport = 0,
        Collision = 1,
        ReturnToGarage = 2,
        WrongStartingPos = 3,
        OvertakeQuali = 4,
        OvertakeOffTrack = 5,
        DriverReport = 6
    }

    public enum IncidentPropCategory
    {
        OriginalReport = 0,
        Report = 1,
        Description = 2,
        Decision = 3,
        Status = 4
    }

    public enum FormationLapType
    {
        Manual = 0,
        ManualShort = 1,
        Controlled = 2,
        ControlledShort = 3,
        Limiter = 4,
        LimiterShort = 5
    }

    public enum DayOfWeekend
    {
        Friday = 1,
        Saturday = 2,
        Sunday = 3
    }

    public enum AccDriverCategory
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2,
        Platinum = 3
    }

    public enum AccCupCategory
    {
        Overall = 0,
        ProAm = 1,
        Am = 2,
        Silver = 3,
        National = 4
    }

    public enum RtgState
    {
        NoRTG = 0,
        Pitlane = 1,
        PitEntry = 2,
        PitExit = 3,
        Track = 4,
    }

    public enum SessionState
    {
        DNS = 0,
        Running = 1,
        Finished = 2,
    }

    public enum DtoType
    {
        Full = 0,
        UniqProps = 1,
        Add = 2,
        Update = 3,
        Filter = 4,
        Filters = 5,
    }

    public enum HttpRequestType
    {
        Get = 0,
        Add = 1,
        Delete = 2,
        Update = 3,
    }

    public enum ProtocolType
    {
        None = 0,
        http = 1,
        https = 2,
    }

    public enum NetworkType
    {
        Localhost = 0,
        IpAdress = 1,
    }

    public enum IpAdressType
    {
        IPv4 = 0,
        IPv6 = 1,
    }

    public enum DiscordChannelType
    {
        Log = 0,
        Registration = 1,
        TrackReport = 2
    }

    public enum DiscordMessageType
    {
        PermanentInfo = 0,
        Commands = 1,
        Entries = 2,
        NewEntries = 3,
        SeasonSettingsViolations = 4,
        BoP = 5,
        Events = 6,
        Cars = 7,
        Organizations = 8,
        Rating = 9
    }
}
