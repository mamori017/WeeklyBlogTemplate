using System;
using System.Globalization;

namespace WeeklyBlogTemplate
{
    public class DateEdit
    {
        /// <summary>
        /// GetWeekStartDate
        /// </summary>
        /// <param name="TargetDate"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDate(DateTime TargetDate)
        {
            DateTime ReturnDate = TargetDate;

            try
            {
                switch (TargetDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        break;
                    case DayOfWeek.Monday:
                        ReturnDate = TargetDate.AddDays(-1);
                        break;
                    case DayOfWeek.Tuesday:
                        ReturnDate = TargetDate.AddDays(-2);
                        break;
                    case DayOfWeek.Wednesday:
                        ReturnDate = TargetDate.AddDays(-3);
                        break;
                    case DayOfWeek.Thursday:
                        ReturnDate = TargetDate.AddDays(-4);
                        break;
                    case DayOfWeek.Friday:
                        ReturnDate = TargetDate.AddDays(-5);
                        break;
                    case DayOfWeek.Saturday:
                        ReturnDate = TargetDate.AddDays(-6);
                        break;
                    default:
                        break;
                }
                return ReturnDate;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

        /// <summary>
        /// GetWeekCount
        /// </summary>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public static int GetWeekCount(DateTime StartDate)
        {
            int Ret = 0;

            try
            {
                Ret = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(StartDate, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
                return Ret;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }
    }
}
