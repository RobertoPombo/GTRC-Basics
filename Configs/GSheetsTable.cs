namespace GTRC_Basics.Configs
{
    public class GSheetsTable
    {
        private string name = string.Empty;
        private string docid = string.Empty;
        private string sheetid = string.Empty;

        public string Name { get { return name; } set { if (GSheetsConfig.GSheetsTableNames.Contains(value)) name = value; } }
        public string DocID { get { return docid; } set { docid = value; } }
        public string SheetID { get { return sheetid; } set { sheetid = value; } }
    }
}
