using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeeklyBlogTemplate.Test
{
    [TestClass()]
    public class DateEditTest
    {
        [TestMethod()]
        public void GetWeekStartDateTest()
        {
            DateTime output = DateEdit.GetWeekStartDate(DateTime.Now);
            DateTime answer = DateTime.Now;

            switch (answer.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    break;
                case DayOfWeek.Monday:
                    answer = answer.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    answer = answer.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    answer = answer.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    answer = answer.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    answer = answer.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    answer = answer.AddDays(-6);
                    break;
                default:
                    break;
            }

            Assert.AreEqual(answer.ToShortDateString(), output.ToShortDateString());
        }

        [TestMethod()]
        public void GetWeekCountTest()
        {
            int answer = 29;
            DateTime dt = DateTime.Parse("2018/07/18");
            int output = DateEdit.GetWeekCount(dt);

            Assert.AreEqual(answer, output);
        }
    }
}
