using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common
{
    public static class FileHelper
    {
        public static List<string> FindDirectories(string rootDirectoryPath, Regex searchRegex, bool includeSubDirectories = false)
        {
            var allDirectoryPaths = GetDirectories(rootDirectoryPath, includeSubDirectories);
            List<string> matchingDirectoryPaths = new List<string>();

            foreach (var directoryPath in allDirectoryPaths)
            {
                var directoryName = new DirectoryInfo(directoryPath).Name;

                if (searchRegex.Match(directoryName).Success)
                    matchingDirectoryPaths.Add(directoryPath);
            }

            return matchingDirectoryPaths;
        }

        public static List<string> GetDirectories(string rootDirectoryPath, bool includeSubDirectories = false)
        {
            // Get all subdirectories
            var directoryPaths = Directory.GetDirectories(rootDirectoryPath).ToList();

            if (!includeSubDirectories || directoryPaths.Count == 0)
                return directoryPaths;

            // Loop through them to see if they have any other subdirectories
            for (var i = 0; i < directoryPaths.Count; i++)
            {
                var subdirectoryPaths = GetDirectories(directoryPaths[i]);
                directoryPaths.AddRange(subdirectoryPaths);
            }

            return directoryPaths;
        }
    }
}
