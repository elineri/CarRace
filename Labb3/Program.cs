using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car() { Name = "Snail", SpeedPerSec = 120000, Distance = 0 };
            Car c2 = new Car() { Name = "Speedy", SpeedPerSec = 120000, Distance = 0 };

            List<Car> placements = new List<Car>();

            Thread t1 = new Thread(() => RaceMethods.Race(c1, placements))
            {
                Name = c1.Name
            };

            Thread t2 = new Thread(() => RaceMethods.Race(c2, placements))
            {
                Name = c2.Name
            };

            Thread info = new Thread(() => RaceMethods.PrintRaceInfo(c1, c2));
            info.IsBackground = true;

            Console.WriteLine("  [Press any key to get race info]\n");

            Console.WriteLine("  Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("  Set...");
            Thread.Sleep(1000);
            Console.WriteLine("  Go!\n");

            t1.Start();
            t2.Start();
            info.Start();
            Console.ReadKey();
        }
    }
}


