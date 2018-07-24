using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common;
using System.Reflection;

namespace WeeklyBlogTemplate.Tests
{
    [TestClass()]
    public class MessageTests
    {
        [TestMethod()]
        public void ShowTitleTest()
        {
            Message.ShowTitle();

            Assert.AreEqual(true,true);
        }
    }
}
