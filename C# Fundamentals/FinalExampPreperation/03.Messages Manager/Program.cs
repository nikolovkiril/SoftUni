using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            int messagesPerUser = int.Parse(Console.ReadLine());
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commSplit = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string firstComm = commSplit[0];
                string name = commSplit[1];
                if (firstComm == "Add")
                {
                    if (!sentMessages.ContainsKey(name) && !receivedMessages.ContainsKey(name))
                    {
                        int send = int.Parse(commSplit[2]);
                        int received = int.Parse(commSplit[3]);
                        sentMessages[name] = send;
                        receivedMessages[name] = received;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (firstComm == "Message")
                {
                    if (sentMessages.ContainsKey(name) && receivedMessages.ContainsKey(name))
                    {
                        string sender = commSplit[1];
                        string receiver = commSplit[2];
                        sentMessages[sender]++;
                        receivedMessages[receiver]++;
                        foreach (var user in receivedMessages)
                        {
                            if (user.Value + receivedMessages[user.Key] >= messagesPerUser)
                            {
                                receivedMessages.Remove(user.Key);
                                sentMessages.Remove(user.Key);
                                Console.WriteLine($"{user.Key} reached the capacity!");
                            }
                        }
                    }
                }
                else if (firstComm == "Empty")
                {
                    string username = commSplit[1];
                    if (username == "All")
                    {
                        sentMessages.Clear();
                        receivedMessages.Clear();
                    }
                    else
                    {
                        sentMessages.Remove(name);
                        receivedMessages.Remove(name);
                    }
                }
                
            }
            int users = receivedMessages.Count();
            Console.WriteLine($"Users count: {users}");

            foreach (var kvp in receivedMessages.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value+sentMessages[kvp.Key]}");
            }
        }
    }
}
