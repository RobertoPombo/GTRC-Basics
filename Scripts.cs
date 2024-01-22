using System.Reflection;

using GTRC_Basics.Models;

namespace GTRC_Basics
{
    public static class Scripts
    {
        public static bool IsValidSteamId(ulong? id)
        {
            return id is not null && id >= GlobalValues.MinSteamId && id <= GlobalValues.MaxSteamId;
        }

        public static bool IsValidDiscordId(ulong? id)
        {
            return id is not null && id >= GlobalValues.MinDiscordId && id <= GlobalValues.MaxDiscordId;
        }

        public static ulong? String2LongSteamId(string? strId)
        {
            ulong id = ulong.MinValue;
            strId = new string(strId?.Where(Char.IsNumber).ToArray());
            _ = ulong.TryParse(strId, out id);
            if (IsValidSteamId(id)) { return id; }
            else { return null; }
        }

        public static ulong? String2LongDiscordId(string? strId)
        {
            ulong id = ulong.MinValue;
            strId = new string(strId?.Where(Char.IsNumber).ToArray());
            _ = ulong.TryParse(strId, out id);
            if (IsValidDiscordId(id)) { return id; }
            else { return null; }
        }

        public static bool IsForeignId(string propertyName)
        {
            if (GetTypeForeignId(propertyName) is null) { return false; }
            else { return true; }
        }

        public static Type? GetTypeForeignId(string propertyName)
        {
            if (propertyName.Length > GlobalValues.Id.Length && propertyName[^GlobalValues.Id.Length..] == GlobalValues.Id)
            {
                foreach (Type type in GlobalValues.ModelTypeList)
                {
                    if (propertyName[..^GlobalValues.Id.Length] == type.Name) { return type; }
                }
                return null;
            }
            return null;
        }

        public static List<Event> SortByDate(List<Event> listEvents)
        {
            for (int index1 = 0; index1 < listEvents.Count - 1; index1++)
            {
                for (int index2 = index1; index2 < listEvents.Count; index2++)
                {
                    if (listEvents[index1].Date > listEvents[index2].Date)
                    {
                        (listEvents[index2], listEvents[index1]) = (listEvents[index1], listEvents[index2]);
                    }
                }
            }
            return listEvents;
        }

        public static string RemoveSpaceStartEnd(string s)
        {
            s ??= string.Empty;
            while (s.Length > 0 && s[..1] == " ") { s = s[1..]; }
            while (s.Length > 0 && s.Substring(s.Length - 1, 1) == " ") { s = s[..^1]; }
            return s;
        }

        public static string StrRemoveSpecialLetters(string str)
        {
            str = str.Replace("ß", "ss");
            str = str.Replace("Ä", "AE"); str = str.Replace("ä", "ae");
            str = str.Replace("Ö", "OE"); str = str.Replace("ö", "oe");
            str = str.Replace("Ü", "UE"); str = str.Replace("ü", "ue");
            str = str.Replace("Á", "A"); str = str.Replace("á", "a");
            str = str.Replace("É", "E"); str = str.Replace("é", "e");
            str = str.Replace("Í", "I"); str = str.Replace("í", "i");
            str = str.Replace("Ó", "O"); str = str.Replace("ó", "o");
            str = str.Replace("Ú", "U"); str = str.Replace("ú", "u");
            str = str.Replace("À", "A"); str = str.Replace("à", "a");
            str = str.Replace("È", "E"); str = str.Replace("è", "e");
            str = str.Replace("Ì", "I"); str = str.Replace("ì", "i");
            str = str.Replace("Ò", "O"); str = str.Replace("ò", "o");
            str = str.Replace("Ù", "U"); str = str.Replace("ù", "u");
            str = str.Replace("Ñ", "N"); str = str.Replace("ñ", "n");
            return str;
        }

        public static string StrRemoveVocals(string str)
        {
            List<string> vocals = ["a", "e", "i", "o", "u"];
            foreach (string vocal in vocals)
            {
                str = str.Replace(vocal.ToLower(), string.Empty);
                str = str.Replace(vocal.ToUpper(), string.Empty);
            }
            return str;
        }

        public static string Ms2Laptime(int ms)
        {
            if (ms == int.MinValue) { ms = int.MaxValue; }
            float flo_input = (float)Math.Abs(ms);
            flo_input /= 1000;
            int int_std = Convert.ToInt32(Math.Floor(flo_input / 3600));
            int int_min = Convert.ToInt32(Math.Floor((flo_input / 60) - 60 * int_std));
            int int_sek = Convert.ToInt32(Math.Floor(flo_input - 60 * (int_min + 60 * int_std)));
            int int_ms = Convert.ToInt32(Math.Round((flo_input - int_sek - 60 * (int_min + 60 * int_std)) * 1000));
            string str_std, str_min, str_sek, str_ms;

            if (int_ms > 99) { str_ms = int_ms.ToString(); }
            else if (int_ms > 9) { str_ms = "0" + int_ms.ToString(); }
            else { str_ms = "00" + int_ms.ToString(); }

            str_sek = int_sek.ToString() + ".";
            if (int_sek < 10 && (int_min > 0 || int_std > 0)) { str_sek = "0" + str_sek; }

            if (int_min == 0 && int_std == 0) { str_min = string.Empty; }
            else
            {
                str_min = int_min.ToString() + ":";
                if (int_min < 10 && int_std > 0) { str_min = "0" + str_min; }
            }

            if (int_std == 0) { str_std = string.Empty; }
            else { str_std = int_std.ToString() + ":"; }

            return str_std + str_min + str_sek + str_ms;
        }

        public static int Laptime2Ms(string laptime)
        {
            int ms = 0;
            string msStr = "0";
            string secStr = "0";
            string minStr = "0";
            string hStr = "0";
            string[] inputArray = laptime.Split(':');
            List<string> inputList1 = [.. inputArray];
            if (inputList1.Count > 2)
            {
                hStr = inputList1[^3];
                if (hStr.Length == 0) { hStr = "0"; }
            }
            if (inputList1.Count > 1)
            {
                minStr = inputList1[^2];
                if (minStr.Length == 0) { minStr = "0"; }
            }
            if (inputList1.Count > 0)
            {
                string[] inputSecArray = inputList1[^1].Split('.', ',');
                List<string> inputList2 = [.. inputSecArray];
                if (inputList2.Count == 1)
                {
                    secStr = inputList2[^1];
                    if (secStr.Length == 0) { secStr = "0"; }
                }
                else if (inputList2.Count > 1)
                {
                    secStr = inputList2[^2];
                    if (secStr.Length == 0) { secStr = "0"; }
                    msStr = inputList2[^1];
                    if (msStr.Length == 0) { msStr = "0"; }
                    else if (msStr.Length == 1) { msStr += "00"; }
                    else if (msStr.Length == 2) { msStr += "0"; }
                }
            }
            if (int.TryParse(msStr, out int msInt) && int.TryParse(secStr, out int secInt) && int.TryParse(minStr, out int minInt) && int.TryParse(hStr, out int hInt))
            {
                ms = msInt + 1000 * (secInt + 60 * (minInt + 60 * hInt));
            }
            return ms;
        }

        public static string ValidatedPath(string path0, string path)
        {

            string pathStart;
            string pathName;
            List<char> BlacklistPathChar = ['/', ':', '*', '?', '"', '<', '>', '|'];

            if (path == null) { path = path0; }

            if (path.Length < 3 || path.Substring(1, 2) != ":\\")
            {
                pathStart = "//";
                pathName = path;
            }
            else
            {
                pathStart = path[..3];
                pathName = path[pathStart.Length..];
                if (!Directory.Exists(pathStart))
                {
                    pathStart = "//";
                }
            }

            foreach (char pathChar in BlacklistPathChar)
            {
                while (pathName.Contains(pathChar))
                {
                    pathName = pathName.Remove(pathName.IndexOf(pathChar), 1);
                }
            }

            if (pathName.Length > 0 && pathName[^1..] != "\\")
            {
                pathName += "\\";
            }

            while (pathName.Length > 0 && pathName[..1] == "\\")
            {
                pathName = pathName[1..];
            }

            while (pathName.Contains("\\\\"))
            {
                pathName = pathName.Remove(pathName.IndexOf("\\\\"), 1);
            }

            path = pathStart + pathName;

            if (path.Length >= path0.Length && path[..path0.Length] == path0)
            {
                path = "//" + path[path0.Length..];
            }

            return path;
        }

        public static string RelativePath2AbsolutePath(string path0, string path)
        {
            if (path.Length > 0 && path[..2] == "//")
            {
                path = path0 + path[2..];
            }
            return path;
        }

        public static bool PathIsParentOf(string path0, string path1, string path2)
        {
            path1 = RelativePath2AbsolutePath(path0, path1);
            path2 = RelativePath2AbsolutePath(path0, path2);
            if (path2.Length >= path1.Length && path1 == path2[..path1.Length]) { return true; }
            else { return false; }
        }

        public static string Date2String(DateTime _date, string parseType)
        {
            int secondint = _date.Second;
            int minuteint = _date.Minute;
            int hourint = _date.Hour;
            int dayint = _date.Day;
            int monthint = _date.Month;
            int yearint = _date.Year;
            string secondstr = secondint.ToString();
            string minutestr = minuteint.ToString();
            string hourstr = hourint.ToString();
            string daystr = dayint.ToString();
            string monthstr = monthint.ToString();
            string yearstr = yearint.ToString();
            if (secondint < 10) { secondstr = "0" + secondstr; }
            if (minuteint < 10) { minutestr = "0" + minutestr; }
            if (hourint < 10) { hourstr = "0" + hourstr; }
            if (dayint < 10) { daystr = "0" + daystr; }
            if (monthint < 10) { monthstr = "0" + monthstr; }
            if (yearint < 10) { yearstr = "0" + yearstr; }
            if (yearint < 100) { yearstr = "0" + yearstr; }
            if (yearint < 1000) { yearstr = "0" + yearstr; }
            int seconddigitcount = 0;
            int minutedigitcount = 0;
            int hourdigitcount = 0;
            int daydigitcount = 0;
            int monthdigitcount = 0;
            int yeardigitcount = 0;
            string text = string.Empty;
            foreach (char currentChar in parseType.Reverse())
            {
                switch (currentChar)
                {
                    case 's': seconddigitcount++; if (seconddigitcount <= secondstr.Length) { text = secondstr.Substring(secondstr.Length - seconddigitcount, 1) + text; } break;
                    case 'm': minutedigitcount++; if (minutedigitcount <= minutestr.Length) { text = minutestr.Substring(minutestr.Length - minutedigitcount, 1) + text; } break;
                    case 'h': hourdigitcount++; if (hourdigitcount <= hourstr.Length) { text = hourstr.Substring(hourstr.Length - hourdigitcount, 1) + text; } break;
                    case 'D': daydigitcount++; if (daydigitcount <= daystr.Length) { text = daystr.Substring(daystr.Length - daydigitcount, 1) + text; } break;
                    case 'M': monthdigitcount++; if (monthdigitcount <= monthstr.Length) { text = monthstr.Substring(monthstr.Length - monthdigitcount, 1) + text; } break;
                    case 'Y': yeardigitcount++; if (yeardigitcount <= yearstr.Length) { text = yearstr.Substring(yearstr.Length - yeardigitcount, 1) + text; } break;
                    default: text = currentChar + text; break;
                }
            }
            return text;
        }

        public static string Ms2String(int ms, string parseType)
        {
            if (ms == int.MinValue) { ms = int.MaxValue; }
            float flo_input = Math.Abs(ms);
            flo_input /= 1000;
            int hInt = Convert.ToInt32(Math.Floor(flo_input / 3600));
            int minInt = Convert.ToInt32(Math.Floor((flo_input / 60) - 60 * hInt));
            int secInt = Convert.ToInt32(Math.Floor(flo_input - 60 * (minInt + 60 * hInt)));
            int msInt = Convert.ToInt32(Math.Round((flo_input - secInt - 60 * (minInt + 60 * hInt)) * 1000));
            string msStr = msInt.ToString();
            string secStr = secInt.ToString();
            string minStr = minInt.ToString();
            string hStr = hInt.ToString();
            if (msInt < 10) { msStr = "0" + msStr; }
            if (msInt < 100) { msStr = "0" + msStr; }
            if (secInt < 10) { secStr = "0" + secStr; }
            if (minInt < 10) { minStr = "0" + minStr; }
            if (hInt < 10) { hStr = "0" + hStr; }
            int msDigitCount = 0;
            int secDigitCount = 0;
            int minDigitCount = 0;
            int hDigitCount = 0;
            string text = string.Empty;
            foreach (char currentChar in parseType.Reverse())
            {
                switch (currentChar)
                {
                    case 'x': msDigitCount++; if (msDigitCount <= msStr.Length) { text = msStr.Substring(msDigitCount - 1, 1) + text; } break;
                    case 's': secDigitCount++; if (secDigitCount <= secStr.Length) { text = secStr.Substring(secStr.Length - secDigitCount, 1) + text; } break;
                    case 'm': minDigitCount++; if (minDigitCount <= minStr.Length) { text = minStr.Substring(minStr.Length - minDigitCount, 1) + text; } break;
                    case 'h': hDigitCount++; if (hDigitCount <= hStr.Length) { text = hStr.Substring(hStr.Length - hDigitCount, 1) + text; } break;
                    default: text = currentChar + text; break;
                }
            }
            return text;
        }

        public static List<PropertyInfo> GetPropertyList(Type type)
        {
            List<PropertyInfo> list = [];
            foreach (PropertyInfo property in type.GetProperties()) { list.Add(property); }
            return list;
        }

        public static dynamic? GetCastedValue(dynamic obj, PropertyInfo property) { try { return CastValue(property, property.GetValue(obj)); } catch { return null; } }

        public static dynamic? CastValue(PropertyInfo property, dynamic? Value)
        {
            string? strValue = Value?.ToString();
            Type type = property.PropertyType;
            if (type == typeof(string) || GlobalValues.ModelTypeList.Contains(type)) { return strValue; }
            else if (type == typeof(bool)) { if (Boolean.TryParse(strValue, out bool cv)) { return cv; } else { return null; } }
            else if (type == typeof(bool?)) { if (Boolean.TryParse(strValue, out bool cv)) { return cv; } else { return null; } }
            else if (type == typeof(byte)) { if (Byte.TryParse(strValue, out byte cv)) { return cv; } else { return null; } }
            else if (type == typeof(byte?)) { if (Byte.TryParse(strValue, out byte cv)) { return cv; } else { return null; } }
            else if (type == typeof(short)) { if (Int16.TryParse(strValue, out short cv)) { return cv; } else { return null; } }
            else if (type == typeof(short?)) { if (Int16.TryParse(strValue, out short cv)) { return cv; } else { return null; } }
            else if (type == typeof(ushort)) { if (UInt16.TryParse(strValue, out ushort cv)) { return cv; } else { return null; } }
            else if (type == typeof(ushort?)) { if (UInt16.TryParse(strValue, out ushort cv)) { return cv; } else { return null; } }
            else if (type == typeof(int)) { if (Int32.TryParse(strValue, out int cv)) { return cv; } else { return null; } }
            else if (type == typeof(int?)) { if (Int32.TryParse(strValue, out int cv)) { return cv; } else { return null; } }
            else if (type == typeof(uint)) { if (UInt32.TryParse(strValue, out uint cv)) { return cv; } else { return null; } }
            else if (type == typeof(uint?)) { if (UInt32.TryParse(strValue, out uint cv)) { return cv; } else { return null; } }
            else if (type == typeof(long)) { if (Int64.TryParse(strValue, out long cv)) { return cv; } else { return null; } }
            else if (type == typeof(long?)) { if (Int64.TryParse(strValue, out long cv)) { return cv; } else { return null; } }
            else if (type == typeof(ulong)) { if (UInt64.TryParse(strValue, out ulong cv)) { return cv; } else { return null; } }
            else if (type == typeof(ulong?)) { if (UInt64.TryParse(strValue, out ulong cv)) { return cv; } else { return null; } }
            else if (type == typeof(float)) { if (Single.TryParse(strValue, out float cv)) { return cv; } else { return null; } }
            else if (type == typeof(float?)) { if (Single.TryParse(strValue, out float cv)) { return cv; } else { return null; } }
            else if (type == typeof(double)) { if (Double.TryParse(strValue, out double cv)) { return cv; } else { return null; } }
            else if (type == typeof(double?)) { if (Double.TryParse(strValue, out double cv)) { return cv; } else { return null; } }
            else if (type == typeof(decimal)) { if (Decimal.TryParse(strValue, out decimal cv)) { return cv; } else { return null; } }
            else if (type == typeof(decimal?)) { if (Decimal.TryParse(strValue, out decimal cv)) { return cv; } else { return null; } }
            else if (type == typeof(DateTime)) { if (DateTime.TryParse(strValue, out DateTime cv)) { return cv; } else { return null; } }
            else if (type == typeof(DateTime?)) { if (DateTime.TryParse(strValue, out DateTime cv)) { return cv; } else { return null; } }
            else if (type == typeof(DateOnly)) { if (DateOnly.TryParse(strValue, out DateOnly cv)) { return cv; } else { return null; } }
            else if (type == typeof(DateOnly?)) { if (DateOnly.TryParse(strValue, out DateOnly cv)) { return cv; } else { return null; } }
            else if (type == typeof(TimeSpan)) { if (TimeSpan.TryParse(strValue, out TimeSpan cv)) { return cv; } else { return null; } }
            else if (type == typeof(TimeSpan?)) { if (TimeSpan.TryParse(strValue, out TimeSpan cv)) { return cv; } else { return null; } }
            else if (type == typeof(TimeUnit)) { if (TimeUnit.TryParse(strValue, out TimeUnit cv)) { return cv; } else { return null; } }
            else if (type == typeof(TimeUnit?)) { if (TimeUnit.TryParse(strValue, out TimeUnit cv)) { return cv; } else { return null; } }
            else if (type == typeof(SessionType)) { if (SessionType.TryParse(strValue, out SessionType cv)) { return cv; } else { return null; } }
            else if (type == typeof(SessionType?)) { if (SessionType.TryParse(strValue, out SessionType cv)) { return cv; } else { return null; } }
            else if (type == typeof(ServerType)) { if (ServerType.TryParse(strValue, out ServerType cv)) { return cv; } else { return null; } }
            else if (type == typeof(ServerType?)) { if (ServerType.TryParse(strValue, out ServerType cv)) { return cv; } else { return null; } }
            else if (type == typeof(EntrylistType)) { if (EntrylistType.TryParse(strValue, out EntrylistType cv)) { return cv; } else { return null; } }
            else if (type == typeof(EntrylistType?)) { if (EntrylistType.TryParse(strValue, out EntrylistType cv)) { return cv; } else { return null; } }
            else if (type == typeof(IncidentsStatus)) { if (IncidentsStatus.TryParse(strValue, out IncidentsStatus cv)) { return cv; } else { return null; } }
            else if (type == typeof(IncidentsStatus?)) { if (IncidentsStatus.TryParse(strValue, out IncidentsStatus cv)) { return cv; } else { return null; } }
            else if (type == typeof(ReportReason)) { if (ReportReason.TryParse(strValue, out ReportReason cv)) { return cv; } else { return null; } }
            else if (type == typeof(ReportReason?)) { if (ReportReason.TryParse(strValue, out ReportReason cv)) { return cv; } else { return null; } }
            else if (type == typeof(IncidentPropCategory)) { if (IncidentPropCategory.TryParse(strValue, out IncidentPropCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(IncidentPropCategory?)) { if (IncidentPropCategory.TryParse(strValue, out IncidentPropCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(FormationLapType)) { if (FormationLapType.TryParse(strValue, out FormationLapType cv)) { return cv; } else { return null; } }
            else if (type == typeof(FormationLapType?)) { if (FormationLapType.TryParse(strValue, out FormationLapType cv)) { return cv; } else { return null; } }
            else if (type == typeof(DayOfWeekend)) { if (DayOfWeekend.TryParse(strValue, out DayOfWeekend cv)) { return cv; } else { return null; } }
            else if (type == typeof(DayOfWeekend?)) { if (DayOfWeekend.TryParse(strValue, out DayOfWeekend cv)) { return cv; } else { return null; } }
            else if (type == typeof(AccDriverCategory)) { if (AccDriverCategory.TryParse(strValue, out AccDriverCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(AccDriverCategory?)) { if (AccDriverCategory.TryParse(strValue, out AccDriverCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(AccCupCategory)) { if (AccCupCategory.TryParse(strValue, out AccCupCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(AccCupCategory?)) { if (AccCupCategory.TryParse(strValue, out AccCupCategory cv)) { return cv; } else { return null; } }
            else if (type == typeof(RtgState)) { if (RtgState.TryParse(strValue, out RtgState cv)) { return cv; } else { return null; } }
            else if (type == typeof(RtgState?)) { if (RtgState.TryParse(strValue, out RtgState cv)) { return cv; } else { return null; } }
            else if (type == typeof(SessionState)) { if (SessionState.TryParse(strValue, out SessionState cv)) { return cv; } else { return null; } }
            else if (type == typeof(SessionState?)) { if (SessionState.TryParse(strValue, out SessionState cv)) { return cv; } else { return null; } }
            else if (type == typeof(DtoType)) { if (DtoType.TryParse(strValue, out DtoType cv)) { return cv; } else { return null; } }
            else if (type == typeof(DtoType?)) { if (DtoType.TryParse(strValue, out DtoType cv)) { return cv; } else { return null; } }
            else if (type == typeof(HttpRequestType)) { if (HttpRequestType.TryParse(strValue, out HttpRequestType cv)) { return cv; } else { return null; } }
            else if (type == typeof(HttpRequestType?)) { if (HttpRequestType.TryParse(strValue, out HttpRequestType cv)) { return cv; } else { return null; } }
            else if (type == typeof(ProtocolType)) { if (ProtocolType.TryParse(strValue, out ProtocolType cv)) { return cv; } else { return null; } }
            else if (type == typeof(ProtocolType?)) { if (ProtocolType.TryParse(strValue, out ProtocolType cv)) { return cv; } else { return null; } }
            else if (type == typeof(NetworkType)) { if (NetworkType.TryParse(strValue, out NetworkType cv)) { return cv; } else { return null; } }
            else if (type == typeof(NetworkType?)) { if (NetworkType.TryParse(strValue, out NetworkType cv)) { return cv; } else { return null; } }
            else if (type == typeof(IpAdressType)) { if (IpAdressType.TryParse(strValue, out IpAdressType cv)) { return cv; } else { return null; } }
            else if (type == typeof(IpAdressType?)) { if (IpAdressType.TryParse(strValue, out IpAdressType cv)) { return cv; } else { return null; } }
            else if (type == typeof(System.Drawing.Color)) { return null; }
            else if (type == typeof(System.Drawing.Color?)) { return null; }
            else { return null; }
        }
    }
}
