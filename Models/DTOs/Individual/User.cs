using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class UserFullDto : User
    {
        public string FullName { get { return FirstName + " " + LastName; } set { } }

        public string ShortName
        {
            get
            {
                string _shortName = string.Empty;
                List<char> cList = [' ', '-'];
                if (FirstName is not null)
                {
                    for (int index = 0; index < FirstName.Length - 1; index++)
                    {
                        if (_shortName.Length == 0 && !cList.Contains(FirstName[index]))
                        {
                            _shortName = FirstName[index].ToString() + ".";
                        }
                        else if (cList.Contains(FirstName[index]) && !cList.Contains(FirstName[index + 1]))
                        {
                            _shortName += FirstName[index].ToString() + FirstName[index + 1].ToString() + ".";
                        }
                    }
                    _shortName += " " + LastName;
                }
                else { _shortName = LastName; }
                return _shortName;
            }
            set { }
        }

        public List<string> GetName3DigitsOptions()
        {
            List<string> listFirstNames; List<string> listLastNames;
            List<string> tempListN3D = [];
            listFirstNames = FilterLetters4N3D(FirstName);
            listLastNames = FilterLetters4N3D(LastName);
            List<string> listAllNames = [.. listFirstNames, .. listLastNames];
            tempListN3D = AddN3D(tempListN3D, Name3Digits);
            string n3D = "";
            foreach (string _name in listLastNames) { n3D += _name[0]; }
            tempListN3D = AddN3D(tempListN3D, n3D);
            n3D = "";
            foreach (string _name in listAllNames) { n3D += _name[0]; }
            tempListN3D = AddN3D(tempListN3D, n3D);
            foreach (string _name in listLastNames) { tempListN3D = AddN3D(tempListN3D, _name); }
            n3D = "";
            foreach (string _name in listLastNames) { n3D += _name; }
            tempListN3D = AddN3D(tempListN3D, n3D);
            foreach (string _fname in listFirstNames)
            {
                n3D = _fname[..1];
                foreach (string _name in listLastNames) { n3D += _name; }
                tempListN3D = AddN3D(tempListN3D, n3D);
            }
            n3D = "";
            foreach (string _name in listLastNames)
            {
                n3D += _name[..1] + Scripts.StrRemoveVocals(_name[1..]);
            }
            tempListN3D = AddN3D(tempListN3D, n3D);
            foreach (string _fname in listFirstNames)
            {
                n3D = _fname[..1];
                foreach (string _name in listLastNames)
                {
                    n3D += _name[..1] + Scripts.StrRemoveVocals(_name[1..]);
                }
                tempListN3D = AddN3D(tempListN3D, n3D);
            }
            foreach (string _fname in listFirstNames) { tempListN3D = AddN3D(tempListN3D, _fname); }
            n3D = "";
            foreach (string _name in listLastNames)
            {
                n3D += _name[..1] + Scripts.StrRemoveVocals(_name[1..]);
            }
            if (n3D.Length > 2)
            {
                for (int charNr1 = 1; charNr1 < n3D.Length - 1; charNr1++)
                {
                    for (int charNr2 = charNr1 + 1; charNr2 < n3D.Length; charNr2++)
                    {
                        tempListN3D = AddN3D(tempListN3D, n3D[..1] + n3D[charNr1] + n3D[charNr2]);
                    }
                }
            }
            foreach (string _fname in listFirstNames)
            {
                n3D = _fname[..1];
                foreach (string _name in listLastNames)
                {
                    n3D += _name[..1] + Scripts.StrRemoveVocals(_name[1..]);
                }
                if (n3D.Length > 2)
                {
                    for (int charNr = 2; charNr < n3D.Length; charNr++)
                    {
                        tempListN3D = AddN3D(tempListN3D, n3D[..2] + n3D[charNr]);
                    }
                }
            }
            n3D = "";
            foreach (string _name in listLastNames) { n3D += Scripts.StrRemoveVocals(_name[1..]); }
            if (n3D.Length > 2)
            {
                for (int charNr1 = 1; charNr1 < n3D.Length - 1; charNr1++)
                {
                    for (int charNr2 = charNr1 + 1; charNr2 < n3D.Length; charNr2++)
                    {
                        tempListN3D = AddN3D(tempListN3D, n3D[..1] + n3D[..1] + n3D[charNr2]);
                    }
                }
            }
            foreach (string _fname in listFirstNames)
            {
                n3D = _fname[..1];
                foreach (string _name in listLastNames) { n3D += _name; }
                if (n3D.Length > 2)
                {
                    for (int charNr = 2; charNr < n3D.Length; charNr++)
                    {
                        tempListN3D = AddN3D(tempListN3D, n3D[..2] + n3D[charNr]);
                    }
                }
            }
            n3D = "";
            foreach (string _name in listAllNames) { n3D += _name; }
            n3D += "XXX";
            return AddN3D(tempListN3D, n3D);
        }

        public static List<string> AddN3D(List<string> tempListN3D, string n3D)
        {
            if (n3D.Length > 2 && !tempListN3D.Contains(n3D[..3])) { tempListN3D.Add(n3D[..3]); }
            return tempListN3D;
        }

        public static List<string> FilterLetters4N3D(string name)
        {
            name = Scripts.StrRemoveSpecialLetters(name);
            name = name.ToUpper();
            name = name.Replace("-", " ");
            List<string> nameList = [];
            foreach (string _name in name.Split(' ')) { if (_name.Length > 0) { nameList.Add(_name); } }
            return nameList;
        }
    }


    public class UserUniqPropsDto0 : Mapper<User>
    {
        [Required] public ulong SteamId { get; set; } = User.MinSteamId;
    }

    public class UserUniqPropsDto1 : Mapper<User>
    {
        [Required] public ulong DiscordId { get; set; } = User.NoDiscordId;
    }


    public class UserAddDto : Mapper<User>
    {
        public ulong? SteamId { get; set; }
        public ulong? DiscordId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? BanDate { get; set; }
        public string? Name3Digits { get; set; }
        public short? EloRating { get; set; }
        public short? SafetyRating { get; set; }
        public byte? Warnings { get; set; }
        public string? DiscordName { get; set; }
        public bool? IsOnDiscordServer { get; set; }
        public string? AccessToken { get; set; }
    }


    public class UserUpdateDto : UserAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class UserFilterDto : UserAddDto
    {
        public int? Id { get; set; }
    }


    public class UserFilterDtos
    {
        public UserFilterDto Filter { get; set; } = new();
        public UserFilterDto FilterMin { get; set; } = new();
        public UserFilterDto FilterMax { get; set; } = new();
    }
}
