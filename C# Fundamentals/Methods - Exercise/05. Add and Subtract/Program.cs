using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            Console.WriteLine(SumNums(numOne,numTwo)-numThree);

        }

        static int SumNums(int numOne ,int numTwo)
        {
            return numOne + numTwo;
        }

       // static int SubtractNums(SumNums , int )
    }
}
