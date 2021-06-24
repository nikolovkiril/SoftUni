using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            var elements = input.Split().Skip(1).ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            while (input != "END")
            {
                switch (input)
                {
                    case "Move":
                        bool result = listyIterator.Move();
                        Console.WriteLine(result);
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (Exception asa)
                        {

                            Console.WriteLine(asa.Message);
                        }
                        break;
                    case "HasNext":
                        result = listyIterator.HasNext();
                        Console.WriteLine(result);
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
