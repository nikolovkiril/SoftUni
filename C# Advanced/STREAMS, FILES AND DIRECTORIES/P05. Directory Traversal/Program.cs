using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string extensionToSearch = "*.*";
            string path = "./";

            string[] fileNames = Directory.GetFiles(path, extensionToSearch);

            var result = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in fileNames)
            {
                FileInfo fileInfo = new FileInfo(item);
                string extension = fileInfo.Extension;
                string fileName = fileInfo.Name;
                double fileSize = fileInfo.Length / 1024.0;
                if (!result.ContainsKey(extension))
                {
                    result.Add(extension, new Dictionary<string, double>());
                }
                result[extension].Add(fileName, fileSize);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var (extension , fileName )in result.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                sb.AppendLine(extension);
                foreach (var fileSize in fileName.OrderBy(x=>x.Value))
                {
                    sb.AppendLine($"--{fileSize.Key} - {fileSize.Value:f3}kb");
                }
            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string resultPath = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(resultPath, sb.ToString());
        }
    }
}
