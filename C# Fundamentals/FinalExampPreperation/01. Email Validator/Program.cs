using System;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input;
            int count = 0;
            string extractWord = "";

            while (!(input = Console.ReadLine()).Contains("Complete"))
            {
                string[] commSplit = input.Split(" ");

                if (input == "Make Upper")
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (input == "Make Lower")
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (commSplit[0] == "GetDomain")
                {
                    int num = int.Parse(commSplit[1]);
                    extractWord = email.Substring(email.Length - num);
                    Console.WriteLine(extractWord);
                }
                else if (commSplit[0] == "GetUsername")
                {
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                break;
                            }
                            count++;
                        }
                        extractWord = email.Substring(0, count);
                        Console.WriteLine(extractWord);
                    }
                }
                else if (commSplit[0] == "Replace")
                {
                    char[] oneTwo = email.ToCharArray();
                    for (int i = 0; i < oneTwo.Length; i++)
                    {
                        char twoOne = char.Parse(commSplit[1]);
                        if (oneTwo[i] == twoOne)
                        {
                            oneTwo[i] = '-';
                        }
                    }
                    Console.WriteLine(oneTwo);
                }
                else if (commSplit[0] == "Encrypt")
                {
                    char[] oneTwo = email.ToCharArray();
                    for (int i = 0; i < oneTwo.Length; i++)
                    {
                        Console.Write($"{(int)oneTwo[i]} ");
                    }
                    Console.WriteLine();
                    //continue;
                        
                }
            }
        }
    }
}
