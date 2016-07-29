using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arcteryx.Utilities.Test
{
    [TestClass]
    public class StringExtensionsUnitTests
    {
        [TestMethod]
        public void Test_Left()
        {
            var n = "123abc";

            Assert.AreEqual(n.Left(3), "123");
            Assert.AreEqual(n.Left(10), n);
            Assert.AreEqual(n.Left(-1), "");
            Assert.AreEqual(n.Left(0), "");

            n = null;

            Assert.AreEqual(n.Left(1), "");
            Assert.AreEqual("".Left(1), "");
        }

        [TestMethod]
        public void Test_Right()
        {
            var n = "123abc";

            Assert.AreEqual(n.Right(3), "abc");
            Assert.AreEqual(n.Right(10), n);
            Assert.AreEqual(n.Right(-1), "");
            Assert.AreEqual(n.Right(0), "");

            n = null;

            Assert.AreEqual(n.Right(1), "");
            Assert.AreEqual("".Right(1), "");
        }

        [TestMethod]
        public void Test_ToAscii()
        {
            var n = "I Åm Ü ☂";

            Assert.AreEqual(n.ToAscii('?'), "I ?m ? ?");
        }

        [TestMethod]
        public void Test_LatinToAscii()
        {
            var n = "I Åm Ü ☂";

            Assert.AreEqual(n.LatinToAscii(), "I Am U ");
        }
    }
}
