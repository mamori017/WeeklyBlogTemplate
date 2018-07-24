using System;
using System.IO;
using WeeklyBlogTemplate.Properties;

namespace WeeklyBlogTemplate
{
    public class Message
    {
        /// <summary>
        /// ShowTitle
        /// </summary>
        public static void ShowTitle()
        {
            Console.WriteLine(StringFormat.Default.Title);
        }

        /// <summary>
        /// ShowFinishedMessage
        /// </summary>
        /// <param name="OutputPath"></param>
        /// <param name="finished"></param>
        public static void ShowFinishedMessage(bool finished = false)
        {
            if (finished)
            {
                Console.WriteLine(string.Format(StringFormat.Default.Output,Path.GetFullPath(Settings.Default.OutputFileName)) + "\n" + StringFormat.Default.Finish);
            }
            else
            {
                Console.WriteLine(StringFormat.Default.Error);
            }
            Console.WriteLine(StringFormat.Default.Press);
            Console.ReadKey();
        }

        /// <summary>
        /// ShowTargetWeek
        /// </summary>
        public static void ShowTargetWeek(DateTime startDate, int weekCount)
        {
            Console.WriteLine(StringFormat.Default.TargetWeek, weekCount, startDate.ToShortDateString(), startDate.AddDays(6).ToShortDateString());
        }

    }
}

