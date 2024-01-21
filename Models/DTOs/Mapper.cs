using GTRC_Basics.Models.Common;
using System.Reflection;

namespace GTRC_Basics.Models.DTOs
{
    public class Mapper<ModelType> where ModelType : class, IBaseModel, new()
    {
        public static dynamic Map(dynamic sourceObject, dynamic returnObject, bool acceptNull = false)
        {
            foreach (PropertyInfo sourceProperty in sourceObject.GetType().GetProperties())
            {
                foreach (PropertyInfo returnProperty in returnObject.GetType().GetProperties())
                {
                    if (sourceProperty.Name == returnProperty.Name &&
                        ((acceptNull && Nullable.GetUnderlyingType(returnProperty.PropertyType) is not null) || sourceProperty.GetValue(sourceObject) is not null))
                    {
                        returnProperty.SetValue(returnObject, sourceProperty.GetValue(sourceObject));
                        break;
                    }
                }
            }
            return returnObject;
        }

        public ModelType Dto2Model(ModelType? obj = null) { if (obj is null) { return Map(this, new ModelType()); } else { return Map(this, obj); } }

        public void Model2Dto(ModelType obj) { Map(obj, this, true); }

        public dynamic Dto2FullDto() { return Map(this, Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][DtoType.Full])!); }

        public static dynamic Model2FullDto(ModelType obj) { return Map(obj, Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][DtoType.Full])!, true); }

        public bool IsSimilar(ModelType obj, bool acceptNull = false)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                foreach (PropertyInfo objProperty in obj.GetType().GetProperties())
                {
                    var thisValue = Scripts.GetCastedValue(this, property);
                    var objValue = Scripts.GetCastedValue(obj, objProperty);
                    if (property.Name == objProperty.Name && (acceptNull || thisValue is not null) && thisValue != objValue &&
                        (thisValue?.ToString().Length > 0 || objValue?.ToString().Length > 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
