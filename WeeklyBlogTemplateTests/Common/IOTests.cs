﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WeeklyBlogTemplateTests.Properties;

namespace Common.Tests
{
    [TestClass()]
    public class IOTests
    {
        [TestMethod()]
        public static void DirectoryCheckOnlyTest()
        {
            // Directory not exist
            // Directory check only
            if (Directory.Exists(Settings.Default.IODirectoryPath))
            {
                Directory.Delete(Settings.Default.IODirectoryPath);
            }

            Assert.AreEqual(true, IO.DirectoryCheck(Settings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public static void DirectoryCheckAndCreateNewOneTest()
        {
            // Directory not exist
            // Directory check and create new one

            if (IO.DirectoryCheck(Settings.Default.IODirectoryPath, true))
            {
                Assert.AreEqual(true, Directory.Exists(Settings.Default.IODirectoryPath));
            }

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        public static void DirectoryCheckTargetExist()
        {
            // Directory exist
            if (!Directory.Exists(Settings.Default.IODirectoryPath))
            {
                Directory.CreateDirectory(Settings.Default.IODirectoryPath);
            }

            Assert.AreEqual(false, IO.DirectoryCheck(Settings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public static void DirectoryCheckArgumentException()
        {
            try
            {
                // Directory exist
                if (!Directory.Exists(Settings.Default.IODirectoryPath))
                {
                    Directory.CreateDirectory(Settings.Default.IODirectoryPath);
                }
                else
                {
                    Directory.Delete(Settings.Default.IODirectoryPath, true);
                }

                IO.DirectoryCheck("?" + Settings.Default.IODirectoryPath, true);
            }
            finally
            {
                DirectoryCheckTestAfterProcess();
            }
        }

        private static void DirectoryCheckTestAfterProcess()
        {
            // Delete test object
            if (Directory.Exists(Settings.Default.IODirectoryPath))
            {
                Directory.Delete(Settings.Default.IODirectoryPath, true);
            }
        }




        [TestMethod()]
        public static void CreateTextFileTest()
        {
            // Delete test object
            if (Directory.Exists(Settings.Default.IODirectoryPath))
            {
                Directory.Delete(Settings.Default.IODirectoryPath, true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(Settings.Default.IOFilePath,
                  Settings.Default.IOFileName,
                  "test",
                  false,
                  IO.EncodeType.sjis));

            Assert.AreEqual(true, IO.CreateTextFile(Settings.Default.IOFilePath,
                              Settings.Default.IOFileName,
                              "test",
                              true,
                              IO.EncodeType.utf8));



            StreamReader reader = new StreamReader(Settings.Default.IOFilePath + "\\" +
                                                   Settings.Default.IOFileName);

            String a = reader.ReadToEnd();

            Assert.AreEqual(a, "testtest");

            reader.Close();

            File.Delete(Settings.Default.IOFilePath + "\\" +
                                                   Settings.Default.IOFileName);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.IO.IOException))]
        public static void CreateTextFileIOExceptionTest()
        {
            StreamReader reader = null;

            // Delete test object
            if (Directory.Exists(Settings.Default.IODirectoryPath))
            {
                Directory.Delete(Settings.Default.IODirectoryPath, true);
            }

            Assert.AreEqual(true, IO.CreateTextFile(Settings.Default.IOFilePath,
                  Settings.Default.IOFileName,
                  "test",
                  false,
                  IO.EncodeType.utf8));

            try
            {
                reader = new StreamReader(Settings.Default.IOFilePath + "\\" +
                                                       Settings.Default.IOFileName);

                IO.CreateTextFile(Settings.Default.IOFilePath,
                      Settings.Default.IOFileName,
                      "test",
                      false,
                      IO.EncodeType.utf8);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    Directory.Delete(Settings.Default.IODirectoryPath, true);
                }
            }

        }
    }
}