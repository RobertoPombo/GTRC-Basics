using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class UserRoleFullDto : UserRole
    {

    }


    public class UserRoleUniqPropsDto0 : Mapper<UserRole>
    {
        [Required] public int UserId { get; set; }
        [Required] public int RoleId { get; set; }
    }


    public class UserRoleAddDto : Mapper<UserRole>
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }


    public class UserRoleUpdateDto : UserRoleAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class UserRoleFilterDto : UserRoleAddDto
    {
        public int? Id { get; set; }
        public string? User { get; set; }
        public string? Role { get; set; }
    }


    public class UserRoleFilterDtos
    {
        public UserRoleFilterDto Filter { get; set; } = new();
        public UserRoleFilterDto FilterMin { get; set; } = new();
        public UserRoleFilterDto FilterMax { get; set; } = new();
    }
}
