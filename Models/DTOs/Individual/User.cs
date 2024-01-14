using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class UserFullDto : User
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set { }
        }

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
        public string? SteamLoginToken { get; set; }
        public string? DiscordLoginToken { get; set; }
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


    public class UserFirstDiscordLoginDto : Mapper<User>
    {
        public ulong? SteamId { get; set; }
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        public string? NickName { get; set; }
    }
}
