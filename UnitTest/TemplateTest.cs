using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeeklyBlogTemplate.Test
{
    [TestClass]
    public class TemplateTest
    {
        readonly DateTime dt = DateTime.Parse("2018/07/18");

        [TestMethod]
        public void GetTitleFormatTest()
        {
            string answer = "2018年 第29週";
            string output = Template.GetTitleFormat(DateEdit.GetWeekStartDate(dt), DateEdit.GetWeekCount(dt));

            Assert.AreEqual(answer, output);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.FormatException))]
        public void GetTitleFormatExceptionTest()
        {
            string output = Template.GetTitleFormat(dt, Int32.Parse(""));
        }


        [TestMethod]
        public void GetContentFormatTest()
        {
            string answer = "## 7/15=====##### ## 7/16=====##### ## 7/17=====##### ## 7/18=====##### ## 7/19=====##### ## 7/20=====##### ## 7/21=====##### ";
            string output = Template.GetContentFormat(DateEdit.GetWeekStartDate(dt)).Replace("\n", "");

            Assert.AreEqual(answer, output);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.FormatException))]
        public void GetContentFormatExceptionTest()
        {
            string output = Template.GetContentFormat(DateTime.Parse("2018/07/32"));
        }
        
        [TestMethod]
        public void CreateOutputStringTest()
        {
            string answer = "[Title]2018年 第29週[Content]## 7/15=====##### ## 7/16=====##### ## 7/17=====##### ## 7/18=====##### ## 7/19=====##### ## 7/20=====##### ## 7/21=====##### ";
            string output = Template.CreateOutputString(DateEdit.GetWeekStartDate(dt), DateEdit.GetWeekCount(dt)).Replace("\n","");

            Assert.AreEqual(answer, output);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.FormatException))]
        public void CreateOutputStringExceptionTest()
        {
            string output = Template.CreateOutputString(DateTime.Parse("2018/07/32"), 2);
        }
    }
}
