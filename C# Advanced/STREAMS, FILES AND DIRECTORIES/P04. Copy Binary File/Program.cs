using System;
using System.IO;

namespace P04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./copyMe.png";
            using FileStream readFileStream = new FileStream(path, FileMode.OpenOrCreate);
            FileStream writeFileStream = new FileStream("logo.png", FileMode.Create);

            byte[] buffer = new byte[4096];

            while (readFileStream.CanRead)
            {
                int count = readFileStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }
                writeFileStream.Write(buffer);
            }

        }
    }
}
