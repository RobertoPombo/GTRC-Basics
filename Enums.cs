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

    public enum ServerType
    {
        PreQuali = 0,
        Practice = 1,
        Event = 2
    }

    public enum CarClass
    {
        General = 0,
        GT2 = 1,
        GT3 = 2,
        GT4 = 3,
        GTC = 4,
        Cup = 5,
        TCX = 6
    }

    public enum EntrylistType
    {
        None = 0,
        RaceControl = 1,
        AllDrivers = 2,
        Season = 3
    }

    public enum IncidentsStatus
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
        Add = 0,
        Update = 1,
        Filter = 2,
        Filters = 3,
    }
}
