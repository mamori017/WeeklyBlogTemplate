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
            DateTime StartDate;
            string OutPutString = "";
            int WeekCount = 0;

            try
            {                
                Message.ShowTitle();

                DirectoryCheck();

                StartDate = DateEdit.GetWeekStartDate(DateTime.Now);

                WeekCount = DateEdit.GetWeekCount(StartDate);

                Message.ShowTargetWeek(StartDate, WeekCount);

                OutPutString = Template.CreateOutPutString(StartDate, WeekCount);

                if (CreateNewFile(OutPutString))
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

        /// <summary>
        /// DirectoryCheck
        /// </summary>
        private static void DirectoryCheck()
        {
            try
            {
                if (!Directory.Exists(Settings.Default.OutputPath))
                {
                    Directory.CreateDirectory(Settings.Default.OutputPath);
                }

                if (!Directory.Exists(Settings.Default.LogPath))
                {
                    Directory.CreateDirectory(Settings.Default.LogPath);
                }
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }

        /// <summary>
        /// CreateNewFile
        /// </summary>
        /// <param name="OutputString"></param>
        /// <returns></returns>
        private static bool CreateNewFile(string OutputString)
        {
            String OutputFileFullPath = Settings.Default.OutputPath + Settings.Default.OutputFileName;
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter Writer = null;;

            try
            {
                if (File.Exists(OutputFileFullPath))
                {
                    File.Delete(OutputFileFullPath);
                }

                Writer = new StreamWriter(OutputFileFullPath, true, objEncoding);
                Writer.Write(OutputString);
                Writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
        }
    }
}
