using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Common
{
    // https://joshclose.github.io/CsvHelper/

    public class CsvUtil
    {
        public static void Write<T>(IEnumerable<T> obj, string filePath, bool useAutoMapper = false, string delimiter = null)
        {
            using (var textWriter = File.CreateText(filePath))
            {
                var csv = new CsvWriter(textWriter);
                if (useAutoMapper)
                    csv.Configuration.AutoMap<T>();
                if (!string.IsNullOrEmpty(delimiter))
                    csv.Configuration.Delimiter = delimiter;
                csv.WriteRecords(obj);
            }
        }

        public static void Write<T, TMap>(IEnumerable<T> obj, string filePath, string delimiter = null) where TMap : CsvClassMap<T>
        {
            using (var textWriter = File.CreateText(filePath))
            {
                var csv = new CsvWriter(textWriter);
                csv.Configuration.RegisterClassMap<TMap>();
                if (!string.IsNullOrEmpty(delimiter))
                    csv.Configuration.Delimiter = delimiter;
                csv.WriteRecords(obj);
            }
        }

        public static IEnumerable<T> Read<T>(string filePath, bool useAutoMapper = false, string delimiter = null)
        {
            IEnumerable<T> records;

            using (var textReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(textReader);
                if (useAutoMapper)
                    csv.Configuration.AutoMap<T>();
                if (!string.IsNullOrEmpty(delimiter))
                    csv.Configuration.Delimiter = delimiter;
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}
