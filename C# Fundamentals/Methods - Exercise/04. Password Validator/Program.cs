using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (!IsValidLenght(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!IsLetterOrDigit(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!IsAtLeasTwoNum(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (IsValidLenght(password) && IsLetterOrDigit(password) && IsAtLeasTwoNum(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsValidLenght(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }

        static bool IsLetterOrDigit(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsAtLeasTwoNum(string password)
        {
            int digitCount = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCount++;
                }
            }  

            return digitCount >= 2;
        }
    }
}
