using System;
using System.ComponentModel;
using System.Reflection;

namespace Dort.Enum
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get enum <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <example>
        /// <code>
        ///  public enum IntegrationUrl
        ///  {
        ///     [Description("https://www.googleapis.com/")]
        ///     GOOGLE_BOOK = 0
        ///  }
        ///  // Return "https://www.googleapis.com/" after use IntegrationUrl.GOOGLE_BOOK.Description()
        /// </code>
        /// </example>
        /// <param name="value">Enum to have his description getted</param>
        /// <returns>Enum description</returns>
        public static string Description(this System.Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            if (attribute == null)
            {
                throw new NullReferenceException("Enum has no Description");
            }

            return attribute.Description;
        }
    }
}
