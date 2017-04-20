using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Common
{
    // https://joshclose.github.io/CsvHelper/

    public class CsvUtil
    {
        public static void Write<T>(IEnumerable<T> obj, string filePath, bool useAutoMapper = false)
        {
            using (var textWriter = File.CreateText(filePath))
            {
                var csv = new CsvWriter(textWriter);
                if (useAutoMapper)
                    csv.Configuration.AutoMap<T>();
                csv.WriteRecords(obj);
            }
        }

        public static IEnumerable<T> Read<T>(string filePath, bool useAutoMapper = false)
        {
            IEnumerable<T> records;

            using (var textReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(textReader);
                if (useAutoMapper)
                    csv.Configuration.AutoMap<T>();
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}
