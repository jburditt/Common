using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Test
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void Deep_Clone_Using_Json()
        {
            var a = new Foo();
            a.Bar = "a";
            var b = a.CloneJson();
            b.Bar = "b";

            Assert.IsTrue(a.Bar == "a");
            Assert.AreNotEqual(a.Bar, b.Bar);
        }
    }

    public class Foo
    {
        public string Bar;
    }
}
