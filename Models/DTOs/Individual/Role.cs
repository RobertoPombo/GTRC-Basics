using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class RoleFullDto : Role
    {

    }


    public class RoleUniqPropsDto0 : Mapper<Role>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class RoleAddDto : Mapper<Role>
    {
        public string? Name { get; set; }
    }


    public class RoleUpdateDto : RoleAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class RoleFilterDto : RoleAddDto
    {
        public int? Id { get; set; }
    }


    public class RoleFilterDtos
    {
        public RoleFilterDto Filter { get; set; } = new();
        public RoleFilterDto FilterMin { get; set; } = new();
        public RoleFilterDto FilterMax { get; set; } = new();
    }
}
