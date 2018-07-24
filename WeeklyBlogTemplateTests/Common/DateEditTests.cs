using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Common.Tests
{
    [TestClass()]
    public class DateEditTests
    {
        [TestMethod()]
        public static void GetWeekStartDateTest()
        {
            DateTime testDate = DateTime.Parse("2018/07/19");

            DateTime outputDate = DateEdit.GetWeekStartDate(testDate);

            Assert.AreEqual("2018/07/15", outputDate.ToShortDateString());
        }

        [TestMethod()]
        public static void GetWeekCountTest()
        {
            DateTime testDate = DateTime.Parse("2018/07/19");

            int outputCount = DateEdit.GetWeekCount(testDate);

            Assert.AreEqual(29, outputCount);
        }
    }
}