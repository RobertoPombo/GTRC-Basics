using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models.DTOs
{
    public class FilterDtos<ModelType> where ModelType : class, IBaseModel, new()
    {
        private static readonly DtoType dtosType = DtoType.Filters;
        private static readonly DtoType dtoType = DtoType.Filter;
        private static readonly dynamic defDtos = Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][dtosType])!;
        private static readonly dynamic defDto = Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][dtoType])!;
        private dynamic dto = defDtos;
        private dynamic filter = defDto;
        private dynamic filterMin = defDto;
        private dynamic filterMax = defDto;

        public dynamic Dto
        {
            get { return dto; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtosType]) { dto = GetMappedDtos(value); } }
        }

        public dynamic Filter
        {
            get { return filter; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtoType]) { filter = GetMappedDto(value); } }
        }

        public dynamic FilterMin
        {
            get { return filterMin; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtoType]) { filterMin = GetMappedDto(value); } }
        }

        public dynamic FilterMax
        {
            get { return filterMax; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtoType]) { filterMax = GetMappedDto(value); } }
        }

        private static dynamic GetMappedDtos(dynamic _dto)
        {
            dynamic filters = defDtos;
            filters.Filter = Mapper<ModelType>.Map(_dto.Filter, defDto);
            filters.FilterMin = Mapper<ModelType>.Map(_dto.FilterMin, defDto);
            filters.FilterMax = Mapper<ModelType>.Map(_dto.FilterMax, defDto);
            return filters;
        }

        private static dynamic GetMappedDto(dynamic _dto)
        {
            return Mapper<ModelType>.Map(_dto, defDto);
        }
    }
}
