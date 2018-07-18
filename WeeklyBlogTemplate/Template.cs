using System;

namespace WeeklyBlogTemplate
{
    public class Template
    {
        /// <summary>
        /// GetTitleFormat
        /// </summary>
        /// <param name="targetDate"></param>
        /// <param name="weekCount"></param>
        /// <returns></returns>
        public static String GetTitleFormat(DateTime targetDate, int weekCount)
        {
            try
            {
                return string.Format(StringFormat.Default.OutputTitle,targetDate.Year, weekCount);
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

        /// <summary>
        /// GetContentFormat
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public static String GetContentFormat(DateTime startDate)
        {
            String content = "";

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    content += string.Format(StringFormat.Default.OutputContent,"\n", startDate.AddDays(i).Month, startDate.AddDays(i).Day);
                }

                return content;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

        /// <summary>
        /// CreateOutPutString
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="weekCount">Week</param>
        /// <returns></returns>
        public static string CreateOutputString(DateTime startDate, int weekCount)
        {
            try
            {
                return string.Format(StringFormat.Default.OutputText,"\n", GetTitleFormat(startDate, weekCount), GetContentFormat(startDate));
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

    }
}
