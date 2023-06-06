using Migration.Entities;
using System.Reflection;

namespace Migration.Extensions
{
    public static class PropExtension
    {
        public static Type GetPropertyTypeHelper<T>(this T adminLayoutConfig, string name)
        {
            Type myType = typeof(T);
            PropertyInfo myPropInfo = myType.GetProperty(name);
            return myPropInfo.PropertyType;
        }
    }
}
