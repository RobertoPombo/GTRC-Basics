using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class BopFullDto : Bop
    {

    }


    public class BopUniqPropsDto0 : Mapper<Bop>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }


    public class BopAddDto : Mapper<Bop>
    {
        public string? Name { get; set; }
    }


    public class BopUpdateDto : BopAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class BopFilterDto : BopAddDto
    {
        public int? Id { get; set; }
    }


    public class BopFilterDtos
    {
        public BopFilterDto Filter { get; set; } = new();
        public BopFilterDto FilterMin { get; set; } = new();
        public BopFilterDto FilterMax { get; set; } = new();
    }
}
