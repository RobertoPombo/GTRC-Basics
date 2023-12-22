using System.Reflection;

namespace GTRC_Basics.Models.Common
{
    public abstract class BaseModel : IBaseModel
    {
        public static List<List<PropertyInfo>> UniqProps = [[]];
        public int Id { get; set; } = GlobalValues.NoID;
    }
}
