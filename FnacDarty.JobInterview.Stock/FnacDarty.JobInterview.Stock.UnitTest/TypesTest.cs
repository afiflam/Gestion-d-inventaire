using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnacDarty.JobInterview.Stock.UnitTest
{
    [TestClass]
    public class TypesTest
    {
        [TestMethod]

        public void IsValidFnacDateInteger()
        {
            int dateformatted = 20210228;

            bool isCorrect = dateformatted.IsValidFnacDateInteger();

            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void IsValidEAN()
        {
            string ean = "ean00001";

            bool isCorrect = ean.IsValidEAN();

            Assert.IsTrue(isCorrect);
        }
    }
}
