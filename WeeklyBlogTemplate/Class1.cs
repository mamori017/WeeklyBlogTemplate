using System;
using System.IO;
using System.Text;

namespace WeeklyBlogTemplate
{
    class Class1
    {
        /// <summary>
        /// DirectoryCheck
        /// </summary>
        public static bool DirectoryCheck(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                else
                {
                    return false;
                }
                return true;
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
        public static bool CreateNewFile(string outputString)
        {
            String outputFilePath = Settings.Default.OutputPath + Settings.Default.OutputFileName;
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter objWriter = null; ;

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
