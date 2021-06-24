using ShoppingSpree.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Schema;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
