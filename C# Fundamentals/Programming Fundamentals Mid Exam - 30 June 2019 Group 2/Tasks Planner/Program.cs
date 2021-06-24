using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> eachTaskTime = Console.ReadLine()
                                     .Split(' ')
                                     .Select(int.Parse)
                                     .ToList();
            int completed = 0;
            int dropped = 0;
            int incompleted = 0;


            for (int i = 0; i < eachTaskTime.Count; i++)
            {
                if (eachTaskTime[i] == 0)
                {
                    completed++;
                }
                else if (eachTaskTime[i] < 0)
                {
                    dropped++;
                }
            }


            string task;
            while ((task = Console.ReadLine()) != "End")
            {
                string[] currentTask = task.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string taskToDo = currentTask[0];

                if (taskToDo == "Complete")
                {
                    int index = int.Parse(currentTask[1]);
                    if (index >= 0 && index < eachTaskTime.Count)
                    {
                        eachTaskTime[index] = 0;
                        completed++;
                    }
                }
                else if (taskToDo == "Change")
                {
                    int index = int.Parse(currentTask[1]);
                    int time = int.Parse(currentTask[2]);
                    if (index >= 0 && index < eachTaskTime.Count)
                    {
                        eachTaskTime[index] = time;
                    }
                }
                else if (taskToDo == "Drop")
                {
                    int index = int.Parse(currentTask[1]);
                    if (index >= 0 && index < eachTaskTime.Count)
                    {
                        eachTaskTime[index] = -1;
                        dropped++;
                    }
                }
                else if (task == "Count Completed")
                {
                    Console.WriteLine(string.Join("", completed));
                }
                else if (task == "Count Incomplete")
                {
                    for (int i = 0; i < eachTaskTime.Count; i++)
                    {
                        if (eachTaskTime[i] > 0)
                        {
                            incompleted++;
                        }
                    }
                    Console.WriteLine(string.Join("", incompleted));
                }
                else if (task == "Count Dropped")
                {
                    Console.WriteLine(string.Join("", dropped));
                }
            }
            Console.WriteLine(string.Join(" ", eachTaskTime.Where(x => x > 0)));

        }
    }
}

