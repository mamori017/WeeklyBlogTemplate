using System;

namespace WeeklyBlogTemplate
{
    public class Template
    {
        /// <summary>
        /// GetTitleFormat
        /// </summary>
        /// <param name="TargetDate"></param>
        /// <param name="WeekCount"></param>
        /// <returns></returns>
        public static String GetTitleFormat(DateTime TargetDate, int WeekCount)
        {
            try
            {
                return TargetDate.Year + "年 第" + WeekCount + "週"; ;
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
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public static String GetContentFormat(DateTime StartDate)
        {
            DateTime TargetDate;
            String ReturnString = "";

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    TargetDate = StartDate.AddDays(i);
                    ReturnString += "## " + TargetDate.Month + "/" + TargetDate.Day + "\n";
                    ReturnString += "=====\n";
                    ReturnString += "##### \n\n";
                }

                return ReturnString;
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
        /// <param name="StartDate"></param>
        /// <param name="WeekCount">Week</param>
        /// <returns></returns>
        public static string CreateOutPutString(DateTime StartDate, int WeekCount)
        {
            try
            {
                String OutPutString = "";

                OutPutString += "[Title]\n";
                OutPutString += Template.GetTitleFormat(StartDate, WeekCount);
                OutPutString += "\n\n";
                OutPutString += "[Content]\n";
                OutPutString += Template.GetContentFormat(StartDate);

                return OutPutString;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

    }
}
