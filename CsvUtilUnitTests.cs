using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class CsvUnitTests
    {
        private const string FilePath = "C:\\temp\\temp.csv";

        [TestMethod]
        public void Write_Csv()
        {
            var list = new List<int> { 1, 2, 3 };
            CsvUtil.Write(list, FilePath);
        }

        [TestMethod]
        public void Write_Csv_Automap()
        {
            var list = new List<Order>
            {
                new Order { Id = 1, Name = "A" },
                new Order { Id = 2, Name = "B" }
            };

            CsvUtil.Write(list, FilePath, true);
        }

        // NOTE: You must run above test first before running this test. Bad practice but we are not going to use these unit tests, they are more here to show how to use

        [TestMethod]
        public void Read_Csv_Automap()
        {
            var list = CsvUtil.Read<Order>(FilePath, true);
            
            Assert.AreEqual(2, list.Count());
        }
    }

    #region Helpers

    public class Order
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    #endregion
}
