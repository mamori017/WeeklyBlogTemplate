using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class LogTests
    {
        [TestMethod()]
        public void OutputTest()
        {
            Log.Output("test",
                       WeeklyBlogTemplateTests.Properties.Settings.Default.LogFilePath,
                       WeeklyBlogTemplateTests.Properties.Settings.Default.LogFileName);

            Assert.AreEqual(true, File.Exists(WeeklyBlogTemplateTests.Properties.Settings.Default.LogFilePath + "\\" + WeeklyBlogTemplateTests.Properties.Settings.Default.LogFileName));
        }

        [TestMethod()]
        public void ExceptionOutputTest()
        {
            try
            {
                throw new System.ArgumentException("Parameter cannot be null", "original");

            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex,
                                    WeeklyBlogTemplateTests.Properties.Settings.Default.ExFilePath,
                                    WeeklyBlogTemplateTests.Properties.Settings.Default.ExFileName);
            }

            Assert.AreEqual(true, File.Exists(WeeklyBlogTemplateTests.Properties.Settings.Default.ExFilePath + "\\" + WeeklyBlogTemplateTests.Properties.Settings.Default.ExFileName));
        }
    }
}