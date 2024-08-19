using Google.Apis.Sheets.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using System.Text;

namespace GTRC_Basics.Configs
{
    public class GSheetsConfig
    {
        private static readonly string path = GlobalValues.ConfigDirectory + "config googlesheets.json";
        private static readonly string pathCrendentials = GlobalValues.ConfigDirectory + "config googlesheets_credentials.json";
        private static readonly string appName = "GTRC Google-Sheets Registration Syncronization";
        private static readonly string[] scopes = [SheetsService.Scope.Spreadsheets];
        private static GoogleCredential? crendentials;
        private static SheetsService? gSheetService;

        public static readonly List<string> GSheetsTableNames = [
            "Practice Leaderboard",
            "Pre-Qualifying Leaderboard",
            "Balance of Performace",
            "Stewarding",
            "Registered Entries",
            "Final Results",
            "Entries Current Event",
            "Car Changes"];
        public static readonly List<GSheetsConfig> List = [];
        public static readonly string DefaultName = "Preset #1";

        private string name = DefaultName;
        private bool isActive = false;

        public GSheetsConfig(bool createTableList = false)
        {
            if (createTableList) { foreach (string gSheetsTableName in GSheetsTableNames) { TableList.Add(new GSheetsTable() { Name = gSheetsTableName }); } }
            List.Add(this);
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 0)
                {
                    name = value;
                    int nr = 1;
                    string delimiter = " #";
                    string defName = name;
                    string[] defNameList = defName.Split(delimiter);
                    if (defNameList.Length > 1 && int.TryParse(defNameList[^1], out _)) { defName = defName[..^(defNameList[^1].Length + delimiter.Length)]; }
                    while (!IsUniqueName())
                    {
                        name = defName + delimiter + nr.ToString();
                        nr++; if (nr == int.MaxValue) { break; }
                    }
                }
            }
        }

        public List<GSheetsTable> TableList { get; set; } = [];

        public bool IsActive
        {
            get { return isActive; }
            set { if (value != isActive) { if (value) { DeactivateAllConnections(); } isActive = value; } }
        }

        public bool IsUniqueName()
        {
            int listIndexThis = List.IndexOf(this);
            for (int configNr = 0; configNr < List.Count; configNr++)
            {
                if (List[configNr].Name == name && configNr != listIndexThis) { return false; }
            }
            return true;
        }

        public bool Connectivity()
        {
            if (!File.Exists(pathCrendentials)) { return false; }
            try
            {
                using (var stream = new FileStream(pathCrendentials, FileMode.Open, FileAccess.ReadWrite)) { crendentials = GoogleCredential.FromStream(stream).CreateScoped(scopes); }
                gSheetService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer() { HttpClientInitializer = crendentials, ApplicationName = appName, });
                return true;
            }
            catch { return false; }
        }

        public static void LoadJson()
        {
            if (!File.Exists(path)) { File.WriteAllText(path, JsonConvert.SerializeObject(List, Formatting.Indented), Encoding.Unicode); }
            try
            {
                List.Clear();
                _ = JsonConvert.DeserializeObject<List<GSheetsConfig>>(File.ReadAllText(path, Encoding.Unicode)) ?? [];
                GlobalValues.CurrentLogText = "Google-Sheets settings restored.";
            }
            catch { GlobalValues.CurrentLogText = "Restore Google-Sheets settings failed!"; }
            if (List.Count == 0) { _ = new GSheetsConfig(true); }
        }

        public static void SaveJson()
        {
            string text = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(path, text, Encoding.Unicode);
            GlobalValues.CurrentLogText = "Google-Sheets settings saved.";
        }

        public static GSheetsConfig? GetActiveConnection()
        {
            foreach (GSheetsConfig con in List) { if (con.IsActive) { return con; } }
            return null;
        }

        public static void DeactivateAllConnections()
        {
            GSheetsConfig? con = GetActiveConnection();
            if (con is not null) { con.IsActive = false; }
        }

        public static void SetLogTextCredentialsFailure()
        {
            GlobalValues.CurrentLogText = "Invalid credentials. Connection to Google-Sheets failed!";
        }

        public static void SetLogTextActionFailure(string action, string sheetID, string range)
        {
            GlobalValues.CurrentLogText = action + " Google-Sheets range failed! [sheetID: " + sheetID + " | range: " + range + "]";
        }

        public static void SetLogTextTableNotFound(int tableNr)
        {
            GlobalValues.CurrentLogText = "Table definition no " + tableNr.ToString() + "no found!";
        }

        public dynamic LoadRange(int tableNr, string range)
        {
            if (gSheetService is null) { SetLogTextCredentialsFailure(); }
            else if (TableList.Count > tableNr)
            {
                string docId = TableList[tableNr].DocId;
                string sheetId = TableList[tableNr].SheetId;
                try
                {
                    var request = gSheetService.Spreadsheets.Values.Get(docId, $"{sheetId}!" + range);
                    var response = request.Execute();
                    dynamic rows = response.Values;
                    return rows;
                }
                catch { SetLogTextActionFailure("Load", sheetId, range); }
            }
            else { SetLogTextTableNotFound(tableNr); }
            return new List<List<string>>();
        }

        public void ClearRange(int tableNr, string range)
        {
            if (gSheetService is null) { SetLogTextCredentialsFailure(); }
            else if (TableList.Count > tableNr)
            {
                string docId = TableList[tableNr].DocId;
                string sheetId = TableList[tableNr].SheetId;
                try
                {
                    var requestBody = new ClearValuesRequest();
                    var deleteRequest = gSheetService.Spreadsheets.Values.Clear(requestBody, docId, $"{sheetId}!" + range);
                    var deleteResponse = deleteRequest.Execute();
                }
                catch { SetLogTextActionFailure("Clear", sheetId, range); }
            }
            else { SetLogTextTableNotFound(tableNr); }
        }

        public void UpdateRange(int tableNr, string range, List<List<object>> rows)
        {
            if (gSheetService is null) { SetLogTextCredentialsFailure(); }
            else if (TableList.Count > tableNr)
            {
                string docId = TableList[tableNr].DocId;
                string sheetId = TableList[tableNr].SheetId;
                try
                {
                    var valueRange = new ValueRange { Values = new List<IList<object>>() };
                    foreach (List<object> row in rows) { valueRange.Values.Add(row); }
                    var updateRequest = gSheetService.Spreadsheets.Values.Update(valueRange, docId, $"{sheetId}!" + range);
                    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                    var updateResponse = updateRequest.Execute();
                }
                catch { SetLogTextActionFailure("Update", sheetId, range); }
            }
            else { SetLogTextTableNotFound(tableNr); }
        }

        public void UpdateFontColor(int tableNr, List<GSheetsRange> ranges, Models.Color color)
        {
            if (gSheetService is null) { SetLogTextCredentialsFailure(); }
            else if (TableList.Count > tableNr)
            {
                string docId = TableList[tableNr].DocId;
                string sheetId = TableList[tableNr].SheetId;
                try
                {
                    Spreadsheet spreadsheet = gSheetService.Spreadsheets.Get(docId).Execute();
                    Sheet? sheet = spreadsheet.Sheets.FirstOrDefault(s => s.Properties.Title == sheetId);
                    if (sheet is null || sheet.Properties.SheetId is null) { SetLogTextActionFailure("Update", sheetId, string.Empty); }
                    else 
                    {
                        int _sheetId = (int)sheet.Properties.SheetId;
                        var userEnteredFormat = new CellFormat()
                        {
                            TextFormat = new TextFormat()
                            {
                                ForegroundColor = new Color()
                                {
                                    Blue = (float)color.Blue / 255,
                                    Red = (float)color.Red / 255,
                                    Green = (float)color.Green / 255,
                                    Alpha = (float)color.Alpha / 255
                                }
                            }
                        };
                        BatchUpdateSpreadsheetRequest bussr = new()
                        {
                            Requests = new List<Request>()
                        };
                        foreach (GSheetsRange range in ranges)
                        {
                            var updateCellsRequest = new Request()
                            {
                                RepeatCell = new RepeatCellRequest()
                                {
                                    Range = new GridRange()
                                    {
                                        SheetId = _sheetId,
                                        StartColumnIndex = range.Col0,
                                        StartRowIndex = range.Row0,
                                        EndColumnIndex = range.Col1,
                                        EndRowIndex = range.Row1
                                    },
                                    Cell = new CellData()
                                    {
                                        UserEnteredFormat = userEnteredFormat
                                    },
                                    Fields = "userEnteredFormat.textFormat.foregroundColor"
                                }
                            };
                            bussr.Requests.Add(updateCellsRequest);
                        }
                        var response = gSheetService.Spreadsheets.BatchUpdate(bussr, docId).Execute();
                    }
                }
                catch { SetLogTextActionFailure("Update", sheetId, string.Empty); }
            }
            else { SetLogTextTableNotFound(tableNr); }
        }
    }
}
