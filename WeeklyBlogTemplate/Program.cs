using Common;
using System;
using WeeklyBlogTemplate.Properties;

namespace WeeklyBlogTemplate
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DateTime startDate;
            string outputString = "";
            int weekCount = 0;

            try
            {                
                Message.ShowTitle();

                IO.DirectoryCheck(Settings.Default.OutputPath);

                startDate = DateEdit.GetWeekStartDate(DateTime.Now);

                weekCount = DateEdit.GetWeekCount(startDate);

                Message.ShowTargetWeek(startDate, weekCount);

                outputString = Template.CreateOutputString(startDate, weekCount);

                if (IO.CreateTextFile(Settings.Default.OutputPath, Settings.Default.OutputFileName, outputString,false))
                {
                    Message.ShowFinishedMessage(true);
                }
                else
                {
                    Message.ShowFinishedMessage(false);
                }
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex, Settings.Default.LogPath, Settings.Default.LogFileName);
                throw;
            }
        }
    }
}
