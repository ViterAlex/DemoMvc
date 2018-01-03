using System.Collections.Generic;
using System.IO;

namespace DemoMvcApp.Models
{
    public static class CatalogModel
    {
        public static string DirectoryPath;
        public static IEnumerable<string> GetFiles(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            return Directory.EnumerateFiles(path);
        }

        public static IEnumerable<string> GetFiles()
        {
            return GetFiles(DirectoryPath);
        }
    }
}