using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class CarclassFullDto : Carclass
    {

    }


    public class CarclassUniqPropsDto0 : Mapper<Carclass>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class CarclassAddDto : Mapper<Carclass>
    {
        public string? Name { get; set; }
    }


    public class CarclassUpdateDto : CarclassAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class CarclassFilterDto : CarclassAddDto
    {
        public int? Id { get; set; }
    }


    public class CarclassFilterDtos
    {
        public CarclassFilterDto Filter { get; set; } = new();
        public CarclassFilterDto FilterMin { get; set; } = new();
        public CarclassFilterDto FilterMax { get; set; } = new();
    }
}
