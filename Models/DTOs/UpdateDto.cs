using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models.DTOs
{
    public class UpdateDto<ModelType> where ModelType : class, IBaseModel, new()
    {
        private static readonly DtoType dtoType = DtoType.Update;
        private static readonly dynamic defDto = Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][dtoType])!;
        private dynamic dto = defDto;

        public dynamic Dto
        {
            get { return dto; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtoType]) { dto = GetMappedDto(value); } }
        }

        private static dynamic GetMappedDto(dynamic _dto)
        {
            return Mapper<ModelType>.Map(_dto, defDto);
        }
    }
}
