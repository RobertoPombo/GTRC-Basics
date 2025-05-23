﻿using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models.DTOs
{
    public class FullDto<ModelType> where ModelType : class, IBaseModel, new()
    {
        private static readonly DtoType dtoType = DtoType.Full;
        private dynamic dto = Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][dtoType])!;

        public dynamic Dto
        {
            get { return dto; }
            set { if (value.GetType() == GlobalValues.DictDtoModels[typeof(ModelType)][dtoType]) { dto = GetMappedDto(value); } }
        }

        private static dynamic GetMappedDto(dynamic _dto)
        {
            return Scripts.Map(_dto, Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][dtoType])!, true);
        }
    }
}
