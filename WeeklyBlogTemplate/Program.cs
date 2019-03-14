using System;

namespace WeeklyBlogTemplate
{
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Function objFunction;

            try
            {
                objFunction = new Function();
                objFunction.Start();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objFunction = null;
            }

        }
    }
}
