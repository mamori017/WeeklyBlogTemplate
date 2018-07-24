using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common;

namespace WeeklyBlogTemplate.Tests
{
    [TestClass()]
    public class TemplateTests
    {
        readonly DateTime dt = DateTime.Parse("2018/07/18");

        [TestMethod]
        public void GetTitleFormatTest()
        {
            string answer = "2018年 第29週";
            string output = Template.GetTitleFormat(DateEdit.GetWeekStartDate(dt), DateEdit.GetWeekCount(dt));

            Assert.AreEqual(answer, output);
        }
        
        [TestMethod]
        public void GetContentFormatTest()
        {
            string answer = "## 7/15=====##### ## 7/16=====##### ## 7/17=====##### ## 7/18=====##### ## 7/19=====##### ## 7/20=====##### ## 7/21=====##### ";
            string output = Template.GetContentFormat(DateEdit.GetWeekStartDate(dt)).Replace("\n", "");

            Assert.AreEqual(answer, output);
        }
        
        [TestMethod]
        public void CreateOutputStringTest()
        {
            string answer = "[Title]2018年 第29週[Content]## 7/15=====##### ## 7/16=====##### ## 7/17=====##### ## 7/18=====##### ## 7/19=====##### ## 7/20=====##### ## 7/21=====##### ";
            string output = Template.CreateOutputString(DateEdit.GetWeekStartDate(dt), DateEdit.GetWeekCount(dt)).Replace("\n", "");

            Assert.AreEqual(answer, output);
        }
    }
}