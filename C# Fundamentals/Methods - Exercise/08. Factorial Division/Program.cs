using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstFact = PrintFactorial(firstNum);
            double secondFact = PrintFactorial(secondNum);
            double result = firstFact / secondFact;
            Console.WriteLine($"{result:f2}");
        }

        static double PrintFactorial(double n)
        {
            double factorial = 1;
            for (double i = n; i >= 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
