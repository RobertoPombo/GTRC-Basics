using GTRC_Basics.Models.Common;
using System.Reflection;

namespace GTRC_Basics.Models.DTOs
{
    public abstract class Mapper<ModelType> where ModelType : class, IBaseModel, new()
    {
        public static dynamic Map(dynamic sourceObject, dynamic returnObject)
        {
            foreach (PropertyInfo sourceProperty in sourceObject.GetType().GetProperties())
            {
                foreach (PropertyInfo returnProperty in returnObject.GetType().GetProperties())
                {
                    if (sourceProperty.Name == returnProperty.Name && sourceProperty.GetValue(sourceObject) is not null)
                    {
                        returnProperty.SetValue(returnObject, sourceProperty.GetValue(sourceObject));
                    }
                }
            }
            return returnObject;
        }

        public ModelType Map() { return Map(new ModelType()); }

        public ModelType Map(ModelType obj) { return Map(this, obj); }

        public void ReMap(ModelType obj) { Map(obj, this); }

        public dynamic MapToFull() { return Map(this, Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][DtoType.Full])!); }

        public static dynamic MapToFull(ModelType obj) { return Map(obj, Activator.CreateInstance(GlobalValues.DictDtoModels[typeof(ModelType)][DtoType.Full])!); }

        public bool IsSimilar(ModelType obj)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                foreach (PropertyInfo objProperty in obj.GetType().GetProperties())
                {
                    if (property.Name == objProperty.Name && property.GetValue(this) is not null && Scripts.GetCastedValue(this, property) != Scripts.GetCastedValue(obj, objProperty))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
