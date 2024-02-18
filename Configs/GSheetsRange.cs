namespace GTRC_Basics.Configs
{
    public class GSheetsRange
    {
        private int col0 = 0;
        private int row0 = 0;
        private int col1 = 0;
        private int row1 = 0;

        public int Col0 { get { return col0; } set { if (value > 0) { col0 = value; } } }
        public int Row0 { get { return row0; } set { if (value > 0) { row0 = value; } } }
        public int Col1 { get { return col1; } set { if (value > 0) { col1 = value; if (col0 == 0) { col0 = col1 - 1; } } } }
        public int Row1 { get { return row1; } set { if (value > 0) { row1 = value; if (row0 == 0) { row0 = row1 - 1; } } } }
    }
}
