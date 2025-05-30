using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250530
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] dinerState = { 0, 0, 0, 0, 0 };
            bool[] availFork = { true, true, true, true, true };
            int[] dinerTime = { 0, 0, 0, 0, 0 };
            int[] dinnerEatCount = { 0, 0, 0, 0, 0 };
            int cycleCount = 1;

            while (true)
            {
                Console.WriteLine("Cycle: " + cycleCount);
                cycleCount++;

                for (int i = 0; i < 5; i++)
                {
                    if (rnd.Next(2) == 1)
                    {
                        if (dinerState[i] == 0 && availFork[i] && availFork[i + 1])
                        {
                           
                        }
                    }

                        switch (dinerState[i])
                        {
                            case -1:
                                Console.WriteLine($"No forks available for Diner {i} (For {dinerTime[i]} cycles)!");
                                break;

                            case 0:
                                Console.WriteLine($"Diner {i} is still resting! (For {dinerTime[i]} cycles!)");
                                break;

                            case 1:
                                Console.WriteLine($"Diner {i} is still eating! (For {dinerTime[i]} cycles!)");
                                break;
                        }
                }

                Console.ReadKey();
            }
        }
    }
}
