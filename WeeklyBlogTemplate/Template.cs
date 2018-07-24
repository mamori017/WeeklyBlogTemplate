using Common;
using System;
using System.Text;

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
                return string.Format(Properties.StringFormat.Default.OutputTitle,targetDate.Year, weekCount);
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex, Properties.Settings.Default.LogPath, Properties.Settings.Default.LogFileName);
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
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    stringBuilder.Append(string.Format(Properties.StringFormat.Default.OutputContent,"\n", startDate.AddDays(i).Month, startDate.AddDays(i).Day));
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex, Properties.Settings.Default.LogPath, Properties.Settings.Default.LogFileName);
                throw;
            }
            finally
            {
                stringBuilder = null;
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
                return string.Format(Properties.StringFormat.Default.OutputText,"\n", GetTitleFormat(startDate, weekCount), GetContentFormat(startDate));
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex,Properties.Settings.Default.LogPath, Properties.Settings.Default.LogFileName);
                throw;
            }
        }

    }
}
