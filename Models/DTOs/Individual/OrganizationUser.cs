using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class OrganizationUserFullDto : OrganizationUser
    {

    }


    public class OrganizationUserUniqPropsDto0 : Mapper<OrganizationUser>
    {
        [Required] public int OrganizationId { get; set; }
        [Required] public int UserId { get; set; }
    }


    public class OrganizationUserAddDto : Mapper<OrganizationUser>
    {
        public int? OrganizationId { get; set; }
        public int? UserId { get; set; }
    }


    public class OrganizationUserUpdateDto : OrganizationUserAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class OrganizationUserFilterDto : OrganizationUserAddDto
    {
        public int? Id { get; set; }
        public string? Organization { get; set; }
        public string? User { get; set; }
    }


    public class OrganizationUserFilterDtos
    {
        public OrganizationUserFilterDto Filter { get; set; } = new();
        public OrganizationUserFilterDto FilterMin { get; set; } = new();
        public OrganizationUserFilterDto FilterMax { get; set; } = new();
    }
}
