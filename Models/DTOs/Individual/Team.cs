using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class TeamFullDto : Team
    {

    }


    public class TeamUniqPropsDto0 : Mapper<Team>
    {
        [Required] public int SeasonId { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class TeamAddDto : Mapper<Team>
    {
        public int? SeasonId { get; set; }
        public string? Name { get; set; }
        public int? OrganizationId { get; set; }
    }


    public class TeamUpdateDto : TeamAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class TeamFilterDto : TeamAddDto
    {
        public int? Id { get; set; }
        public string? Season { get; set; }
        public string? Organization { get; set; }
    }


    public class TeamFilterDtos
    {
        public TeamFilterDto Filter { get; set; } = new();
        public TeamFilterDto FilterMin { get; set; } = new();
        public TeamFilterDto FilterMax { get; set; } = new();
    }
}
