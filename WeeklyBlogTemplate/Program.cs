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

                DirectoryCheck();

                startDate = DateEdit.GetWeekStartDate(DateTime.Now);

                weekCount = DateEdit.GetWeekCount(startDate);

                Message.ShowTargetWeek(startDate, weekCount);

                outputString = Template.CreateOutputString(startDate, weekCount);

                if (CreateNewFile(outputString))
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
        /// <param name="outputString"></param>
        /// <returns></returns>
        private static bool CreateNewFile(string outputString)
        {
            String outputFilePath = Settings.Default.OutputPath + Settings.Default.OutputFileName;
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter objWriter = null;;

            try
            {
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }

                objWriter = new StreamWriter(outputFilePath, true, objEncoding);
                objWriter.Write(outputString);
                objWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex);
                throw;
            }
            finally
            {
                if (objEncoding != null)
                {
                    objEncoding = null;
                }

                if (objWriter != null)
                {
                    objWriter = null;
                }
            }
        }
    }
}
