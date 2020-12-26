using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace blazing_IT.Components
{
    public class CssClassAttribute : Attribute
    {
        private string _cssClassName;
        public CssClassAttribute(string cssClassName)
        {
            _cssClassName = cssClassName;
        }

        public string CssClassName
        {
            get { return _cssClassName; }
        }

        public static string GetCssClass(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            CssClassAttribute[] attrs = fi.GetCustomAttributes(typeof(CssClassAttribute), false) as CssClassAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].CssClassName;
            }
            return output;
        }
    }

}
