using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class UserFullDto : User
    {
        public string FullName
        {
            get { return GetFullName(this); }
            set { }
        }

        public string ShortName
        {
            get { return GetShortName(this); }
            set { }
        }

        public static string GetFullName(User obj)
        {
            return obj.FirstName + " " + obj.LastName;
        }

        public static string GetShortName(User obj)
        {
            string _shortName = string.Empty;
            List<char> cList = [' ', '-'];
            if (obj.FirstName is not null)
            {
                for (int index = 0; index < obj.FirstName.Length - 1; index++)
                {
                    if (_shortName.Length == 0 && !cList.Contains(obj.FirstName[index]))
                    {
                        _shortName = obj.FirstName[index].ToString() + ".";
                    }
                    else if (cList.Contains(obj.FirstName[index]) && !cList.Contains(obj.FirstName[index + 1]))
                    {
                        _shortName += obj.FirstName[index].ToString() + obj.FirstName[index + 1].ToString() + ".";
                    }
                }
                _shortName += " " + obj.LastName;
            }
            else { _shortName = obj.LastName; }
            return _shortName;
        }
    }


    public class UserUniqPropsDto0 : Mapper<User>
    {
        [Required] public ulong SteamId { get; set; } = ulong.MinValue;
    }

    public class UserUniqPropsDto1 : Mapper<User>
    {
        [Required] public ulong DiscordId { get; set; } = ulong.MinValue;
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
        public string? NickName { get; set; }
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
