using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace blazing_IT.Components
{
    /// <summary>
    /// This attribute can be used in enums to man an enum into CSS classes. 
    /// These enums are usefull to pass them as parameter into Razor Components.
    /// </summary>
    /// <example>
    /// https://github.com/SebHoyer/blazing-IT.Components.FontAwesome/blob/master/blazing-IT.Components.FontAwesome/FaIconSize.cs
    /// </example>
    [AttributeUsage(AttributeTargets.Enum)]
    public class CssClassAttribute : Attribute
    {
        private string _cssClassName;
        /// <summary>
        /// The name of the CSS class, the enum-value gets mapped into.
        /// </summary>
        public string CssClassName
        {
            get { return _cssClassName; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cssClassName">The name of the CSS class, the enum-value gets mapped into.</param>
        public CssClassAttribute(string cssClassName)
        {
            _cssClassName = cssClassName;
        }

        /// <summary>
        /// Resolves the CSS class from a given enum-value.
        /// The enum has to be decorated with the CssClassAttribute
        /// </summary>
        /// <param name="enumValue">The enum-value to resolve</param>
        /// <returns></returns>
        public static string GetCssClass(Enum enumValue)
        {
            Type enumValueType = enumValue.GetType();
            Type cssClassAttributeType = typeof(CssClassAttribute);

            FieldInfo enumValueFieldInfo = enumValueType.GetField(enumValue.ToString());
            CssClassAttribute[] enumValueAttributes = enumValueFieldInfo.GetCustomAttributes(cssClassAttributeType) as CssClassAttribute[];

            string cssClassName = string.Empty;
            if (enumValueAttributes.Length > 0)
            {
                cssClassName = enumValueAttributes[0].CssClassName;
            }

            return cssClassName;
        }
    }

}
