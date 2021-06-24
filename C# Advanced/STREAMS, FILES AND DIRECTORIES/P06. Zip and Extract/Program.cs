using System;
using System.IO;
using System.IO.Compression;

namespace P06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "copyMe.png";        
            using ZipArchive zipArchive = ZipFile.Open("../../../arhiv.zip", ZipArchiveMode.Create);
            zipArchive.CreateEntryFromFile(path, "copyMe2.png");
        }
    }
}
