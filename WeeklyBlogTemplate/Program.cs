using System;
using System.Text;
using System.IO;

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

                Class1.DirectoryCheck(Settings.Default.OutputPath);

                startDate = DateEdit.GetWeekStartDate(DateTime.Now);

                weekCount = DateEdit.GetWeekCount(startDate);

                Message.ShowTargetWeek(startDate, weekCount);

                outputString = Template.CreateOutputString(startDate, weekCount);

                if (Class1.CreateNewFile(outputString))
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
                Log.ExceptionOutput(ex);
                throw;
            }
        }
    }
}
