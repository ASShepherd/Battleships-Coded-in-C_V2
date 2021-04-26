using System;

namespace BattleShips
{
    public static class EnumExtensions
    {
        //Code from https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
        //To allow calling of enum descriptions

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}