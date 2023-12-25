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
    }
}
