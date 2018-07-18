using System;
using System.IO;

namespace WeeklyBlogTemplate
{
    public class Message
    {
        /// <summary>
        /// ShowTitle
        /// </summary>
        public static void ShowTitle()
        {
            Console.WriteLine(Settings.Default.Title);
        }

        /// <summary>
        /// ShowFinishedMessage
        /// </summary>
        /// <param name="OutputPath"></param>
        /// <param name="Finished"></param>
        public static void ShowFinishedMessage(bool Finished = false)
        {
            if (Finished)
            {
                Console.WriteLine("Output   : " + Path.GetFullPath(Settings.Default.OutputFileName));
                Console.WriteLine("\nGenelate finished");
            }
            else
            {
                Console.WriteLine("\nGenelate error");
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        /// <summary>
        /// ShowTargetWeek
        /// </summary>
        public static void ShowTargetWeek(DateTime StartDate, int WeekCount)
        {
            Console.WriteLine("Target   : Week " + WeekCount + "(" + StartDate.ToShortDateString() + "-" + StartDate.AddDays(6).ToShortDateString() + ")");
        }

    }
}

