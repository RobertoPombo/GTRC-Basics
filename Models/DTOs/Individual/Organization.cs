using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class OrganizationFullDto : Organization
    {

    }


    public class OrganizationUniqPropsDto0 : Mapper<Organization>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class OrganizationAddDto : Mapper<Organization>
    {
        public string? Name { get; set; }
    }


    public class OrganizationUpdateDto : OrganizationAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class OrganizationFilterDto : OrganizationAddDto
    {
        public int? Id { get; set; }
    }


    public class OrganizationFilterDtos
    {
        public OrganizationFilterDto Filter { get; set; } = new();
        public OrganizationFilterDto FilterMin { get; set; } = new();
        public OrganizationFilterDto FilterMax { get; set; } = new();
    }
}
