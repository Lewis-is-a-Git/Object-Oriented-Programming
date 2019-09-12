// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 2/09/2019
using System;

namespace Counter
{
    class MainClass
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Value);
            }
        }

        public static void Main(string[] args)
        {
            //Declaring Variables
            Counter[] myCounters = new Counter[3];
            int i; //Loop counter

            // Assigning Values
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            //Increment Counters
            for (i = 0; i < 4; i++)
            {
                myCounters[0].Increment();
            }
            for (i = 0; i < 9; i++)
            {
                myCounters[1].Increment();
            }

            PrintCounters(myCounters);

            myCounters[2].Reset();
            PrintCounters(myCounters);
            // myCounters[2] is reset because the array is a pointer to myCounters[0]
        }
    }
}
