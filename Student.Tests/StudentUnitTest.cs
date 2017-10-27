using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample.tests
{
    [TestClass]
    public class StudentUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollegeStudent student = new CollegeStudent("Rajaraman");
            Assert.AreEqual("Rajaraman", student.Name);
        }
    }
}
