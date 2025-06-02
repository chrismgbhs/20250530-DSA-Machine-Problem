using System;
using System.Threading;

namespace _20250530
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] dinerState = { 0, 0, 0, 0, 0 }; // 0 = waiting, 1 = eating, -1 = resting
            bool[] availFork = { true, true, true, true, true };
            int[] dinerTime = { 0, 0, 0, 0, 0 };
            int[] dinnerEatCount = { 0, 0, 0, 0, 0 };
            int dinerWithLeastCycle = 0;
            int dinerMinTime = 11;
            int cycleCount = 0;
            bool doLoop = true;
            bool allHaveEaten = false;

            int firstDiner = rnd.Next(0, 5);
            int leftFork = firstDiner;
            int rightFork = (firstDiner + 1) % 5;

            dinerState[firstDiner] = 1;
            dinerTime[firstDiner] = rnd.Next(3, 11);
            availFork[leftFork] = false;
            availFork[rightFork] = false;
            dinnerEatCount[firstDiner]++;

            while (doLoop)
            {
                dinerMinTime = 11;
                dinerWithLeastCycle = -1;

                for (int dinerCounter = 0; dinerCounter < dinerState.Length; dinerCounter++)
                {
                    if (dinerTime[dinerCounter] == 0)
                    {
                        if (dinerState[dinerCounter] == 1)
                        {
                            dinerState[dinerCounter] = -1;
                            dinerTime[dinerCounter] = rnd.Next(5, 11);
                            availFork[dinerCounter] = true;
                            availFork[(dinerCounter + 1) % 5] = true;
                        }

                        else if (dinerState[dinerCounter] == -1)
                        {
                            dinerState[dinerCounter] = 0;
                        }
                    }
                }

                for (int dinerCounter = 0; dinerCounter < 5; dinerCounter++)
                {
                    if (dinerState[dinerCounter] == 0 && availFork[dinerCounter] && availFork[(dinerCounter + 1) % 5])
                    {
                        dinerState[dinerCounter] = 1;
                        dinerTime[dinerCounter] = rnd.Next(3, 11);
                        availFork[dinerCounter] = false;
                        availFork[(dinerCounter + 1) % 5] = false;
                        dinnerEatCount[dinerCounter]++;
                    }
                }

                for (int dinerCounter = 0; dinerCounter < 5; dinerCounter++)
                {
                    if (dinerTime[dinerCounter] > 0)
                    {
                        dinerTime[dinerCounter]--;
                    }

                    if (dinerTime[dinerCounter] > 0 && dinerTime[dinerCounter] < dinerMinTime)
                    {
                        dinerMinTime = dinerTime[dinerCounter];
                        dinerWithLeastCycle = dinerCounter;
                    }
                }

                cycleCount++;
                Console.WriteLine($"CYCLE: {cycleCount}");

                for (int i = 0; i < 5; i++)
                {
                    switch (dinerState[i])
                    {
                        case 0:
                            Console.WriteLine($"No forks available for Diner {i + 1}!");
                            break;

                        case 1:
                            Console.WriteLine($"Diner {i + 1} is still eating! (For {dinerTime[i] + 1} cycles!)");
                            break;

                        case -1:
                            Console.WriteLine($"Diner {i + 1} is still resting! (For {dinerTime[i] + 1} cycles!)");
                            break;
                    }
                }

                allHaveEaten = true;
                for (int i = 0; i < 5; i++)
                {
                    if (dinnerEatCount[i] == 0)
                    {
                        allHaveEaten = false;
                        break;
                    }
                }

                if (allHaveEaten)
                {
                    doLoop = false;
                }

                Console.WriteLine();
                Thread.Sleep(500);
            }

            Console.WriteLine($"All diners have finished eating after {cycleCount} cycles!");
            for (int dinerCounter = 0; dinerCounter < dinerState.Length; dinerCounter++)
            {
                Console.WriteLine($"Diner {dinerCounter + 1} had eaten {dinnerEatCount[dinerCounter]}.");
            }
        }
    }
}
