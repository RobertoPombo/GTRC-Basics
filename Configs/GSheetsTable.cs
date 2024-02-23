namespace GTRC_Basics.Configs
{
    public class GSheetsTable
    {
        private string name = string.Empty;
        private string docId = string.Empty;
        private string sheetId = string.Empty;

        public string Name { get { return name; } set { if (GSheetsConfig.GSheetsTableNames.Contains(value)) name = value; } }
        public string DocId { get { return docId; } set { docId = value; } }
        public string SheetId { get { return sheetId; } set { sheetId = value; } }
    }
}
