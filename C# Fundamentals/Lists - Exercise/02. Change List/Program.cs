using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> change = Console.ReadLine()
                                     .Split(' ')
                                     .Select(int.Parse)
                                     .ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command
                     .Split(' ')
                     .ToArray();
                if (cmdArg[0] == "Delete")
                {
                    DeletElement(change, cmdArg);
                }
                if (cmdArg[0] == "Insert")
                {
                    InsertNum(change, cmdArg);
                }
            }
            Console.WriteLine(string.Join(" " , change));
        }

        private static void InsertNum(List<int> change, string[] cmdArg)
        {
            int insertEl = int.Parse(cmdArg[1]);
            int insertPosition = int.Parse(cmdArg[2]);
            change.Insert(insertPosition, insertEl);
        }

        private static void DeletElement(List<int> change, string[] cmdArg)
        {
            int deleteNum = int.Parse(cmdArg[1]);
            change.RemoveAll(x => x == deleteNum);
        }
    }
}
