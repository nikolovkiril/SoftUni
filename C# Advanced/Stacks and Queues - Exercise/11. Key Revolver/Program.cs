using System;
using System.Collections.Generic;
using System.Linq;


namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int prizeValue = int.Parse(Console.ReadLine());

            int bulletCount = 0;

            int reloadind = gunBarrel;

            // he starts to shoot the locks front-to-back, while going through the bullets back-to-front.

            var queuekLocks = new Queue<int>(locks);
            var stackBullets = new Stack<int>(bullets);

            //If the bullet has a smaller or equal size to the current lock, print “Bang!”,
            //then remove the lock. If not, print "Ping!", leaving the lock intact. The bullet is removed in both cases.

            while (stackBullets.Count != 0 && queuekLocks.Count != 0)
            {
                if (stackBullets.Peek() <= queuekLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    queuekLocks.Dequeue();
                    stackBullets.Pop();
                    reloadind--;
                    reloadind = NewMethod(gunBarrel, reloadind, stackBullets);
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackBullets.Pop();
                    reloadind--;
                    reloadind = NewMethod(gunBarrel, reloadind, stackBullets);
                }

                bulletCount++;
                if (stackBullets.Count == 0 && queuekLocks.Count != 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queuekLocks.Count}");
                }
                if (queuekLocks.Count == 0)
                {
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${prizeValue - (bulletCount * priceBullet)}");
                }
            }


            //If Sam runs out of bullets in his barrel, print "Reloading!" on the console, 
            //then continue shooting.If there aren’t any bullets left, don’t print it

            //The program ends when Sam either runs out of bullets, or the safe runs out of locks.



            //If Sam runs out of bullets before the safe runs out of locks, print:
            //"Couldn't get through. Locks left: {locksLeft}"


            //If Sam manages to open the safe, print:
            //"{bulletsLeft} bullets left. Earned ${moneyEarned}"

            //50                                    //Ping!
            //2                                     // Bang!
            //11 10 5 11 10 20                      //Reloading!
            //15 13 16                              //Bang!
            //1500                                  //Bang!
            //Reloading!
            //2 bullets left. Earned $1300
        }

        private static int NewMethod(int gunBarrel, int reloadind, Stack<int> stackBullets)
        {
            if (reloadind == 0 && stackBullets.Count != 0)
            {
                Console.WriteLine("Reloading!");
                reloadind = gunBarrel;
            }

            return reloadind;
        }
    }
}
