namespace GTRC_Basics
{
    public delegate void Notify();

    public static class GlobalValues
    {
        public static readonly int NoID = -1;
        public static readonly int ID0 = 1;
        public static readonly DateTime DateTimeMinValue = DateTime.MinValue.AddYears(1800);
        public static readonly DateTime DateTimeMaxValue = DateTime.MaxValue.AddDays(-1);

        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string currentLogText = " ";

        public static string BaseDirectory { get { return baseDirectory; } set { baseDirectory = value; } }
        public static string DataDirectory { get { return baseDirectory + "data\\"; } }
        public static string CurrentLogText { get { return currentLogText; } set { currentLogText = value; OnNewLogText(); } }

        public static event Notify? NewLogText;
        public static void OnNewLogText() { NewLogText?.Invoke(); }
    }
}
