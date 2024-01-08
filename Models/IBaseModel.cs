using System.Reflection;

namespace GTRC_Basics.Models.Common
{
    public interface IBaseModel
    {
        public static readonly List<List<PropertyInfo>> UniqProps = [[]];
        public int Id { get; set; }
    }
}
