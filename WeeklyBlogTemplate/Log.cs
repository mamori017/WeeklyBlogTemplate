using System;
using System.IO;
using System.Text;

namespace WeeklyBlogTemplate
{
    public class Log
    {
        /// <summary>
        /// ExceptionOutput
        /// </summary>
        public static void ExceptionOutput(Exception ex)
        {
            String OutputLogFileFullPath = Settings.Default.LogPath+ Settings.Default.LogFileName;
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter objWriter = new StreamWriter(OutputLogFileFullPath, true, objEncoding);

            try
            {
                objWriter.WriteLine(ex);
                objWriter.Close();
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
