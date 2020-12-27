using blazing_IT.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace blazing_IT.Tests.Components
{
    [TestClass()]
    public class TestCssClassAttribute
    {
        public enum ValidEnum
        {
            [CssClass("value-1")]
            Value1,

            [CssClass("value-2")]
            Value2,

            [CssClass("value-3")]
            Value3,

            [CssClass("")]
            Value4
        }

        public enum InvalidEnum
        {
            [CssClass("value-1")]
            Value1,

            [CssClass("")]
            Value2Empty,

            Value3NoAttribute
        }


        [TestMethod()]
        public void TestValidEnum()
        {
            ValidEnum valid = ValidEnum.Value1;

            string validCssClass = CssClassAttribute.GetCssClass(valid);
            Assert.AreEqual("value-1", validCssClass);

            valid = ValidEnum.Value2;
            validCssClass = CssClassAttribute.GetCssClass(valid);
            Assert.AreEqual("value-2", validCssClass);

            valid = ValidEnum.Value3;
            validCssClass = CssClassAttribute.GetCssClass(valid);
            Assert.AreEqual("value-3", validCssClass);

            valid = ValidEnum.Value4;
            validCssClass = CssClassAttribute.GetCssClass(valid);
            Assert.AreEqual("", validCssClass);
        }


        [TestMethod()]
        public void TestInvalidEnum()
        {
            InvalidEnum invalid = InvalidEnum.Value1;

            string invalidCssClass = CssClassAttribute.GetCssClass(invalid);
            Assert.AreEqual("value-1", invalidCssClass);

            invalid = InvalidEnum.Value2Empty;
            invalidCssClass = CssClassAttribute.GetCssClass(invalid);
            Assert.AreEqual("", invalidCssClass);

            //invalid = InvalidEnum.Value3NoAttribute;
            //invalidCssClass = CssClassAttribute.GetCssClass(invalid);
            //Assert.AreEqual("", invalidCssClass);
        }
    }
}
