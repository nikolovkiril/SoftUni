
using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class GenericBoxOfString
    {

        static void Main(string[] args)
        {
            int numOfCom = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCom; i++)
            {
                var input = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
