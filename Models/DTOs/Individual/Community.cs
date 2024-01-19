using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class CommunityFullDto : Community
    {

    }


    public class CommunityUniqPropsDto0 : Mapper<Community>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class CommunityAddDto : Mapper<Community>
    {
        public string? Name { get; set; }
    }


    public class CommunityUpdateDto : CommunityAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class CommunityFilterDto : CommunityAddDto
    {
        public int? Id { get; set; }
    }


    public class CommunityFilterDtos
    {
        public CommunityFilterDto Filter { get; set; } = new();
        public CommunityFilterDto FilterMin { get; set; } = new();
        public CommunityFilterDto FilterMax { get; set; } = new();
    }
}
