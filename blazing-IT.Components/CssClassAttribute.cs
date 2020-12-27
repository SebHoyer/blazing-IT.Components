using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace blazing_IT.Components
{
    /// <summary>
    /// This attribute can be used in enums to map enum-values into CSS classes. 
    /// These enums are usefull to pass them as parameter into Razor Components.
    /// </summary>
    /// <example>
    /// https://github.com/SebHoyer/blazing-IT.Components.FontAwesome/blob/master/blazing-IT.Components.FontAwesome/FaIconSize.cs
    /// </example>
    [AttributeUsage(AttributeTargets.Field)]
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
        /// Assigns a CSS class name as string to an enum-value
        /// </summary>
        /// <param name="cssClassName">The name of the CSS class, the enum-value gets mapped into.</param>
        public CssClassAttribute(string cssClassName)
        {
            _cssClassName = cssClassName;
        }

        /// <summary>
        /// Resolves the CSS class from a given enum-value.
        /// The enum-values have to be decorated with the CssClassAttribute
        /// </summary>
        /// <param name="enumValue">The enum-value to resolve</param>
        /// <returns>CSS class name as string</returns>
        /// <exception cref="System.Exception">
        /// An exception gets thrown if one trys to get the css class if the enum-value is not decorated with the CssClassAttribute
        /// </exception>
        public static string GetCssClass(Enum enumValue)
        {
            Type enumValueType = enumValue.GetType();
            Type cssClassAttributeType = typeof(CssClassAttribute);
            string enumValueString = enumValue.ToString();

            FieldInfo enumValueFieldInfo = enumValueType.GetField(enumValueString);
            CssClassAttribute[] enumValueAttributes = enumValueFieldInfo.GetCustomAttributes(cssClassAttributeType) as CssClassAttribute[];

            string cssClassName = string.Empty;

            // Check if the enum-value is decorated with the CssClassAttribute
            if (enumValueAttributes.Length == 0)
            {
                // No decoration found
                throw new Exception($"Enum '{enumValueType.Name.ToString()}' Value: '{enumValue.ToString()}' is not decorated with the CssClassAttribute");
            }
            else 
            {
                // Attribute found
                cssClassName = enumValueAttributes[0].CssClassName;
            }

            return cssClassName;
        }
    }

}
