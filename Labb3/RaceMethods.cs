using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labb3
{
    class RaceMethods
    {
        public static void Race(Car car, List<Car> placements)
        {
            int seconds = 0;
            int raceLength = 10000; // 10km race

            while (car.Distance <= raceLength)
            {
                Console.WriteLine($"  The race has begun for {Thread.CurrentThread.Name}!");
                for (int i = 0; car.Distance <= raceLength; i++)
                {
                    car.Distance = car.Distance + ((car.SpeedPerSec / 60) / 60);
                    Thread.Sleep(1000);
                    seconds++;

                    if (seconds == 30) // Every 30 seconds there should be a risk of an obstacle
                    {
                        car.SpeedPerSec = Obstacle(car);
                        seconds = 0; // Reset seconds
                    }
                }
            }

            Console.WriteLine($"\n  {Thread.CurrentThread.Name} has passed the finished line!");
            placements.Add(car);
            if (Thread.CurrentThread.Name == placements[0].Name)
            {
                Console.WriteLine($"  ►►► {Thread.CurrentThread.Name} won! ◄◄◄");
            }
        }

        public static void PrintRaceInfo(Car c1, Car c2)
        {
            while (true)
            {
                Console.ReadKey();
                Console.WriteLine();
                CarInfo(c1);
                CarInfo(c2);
            }
        }

        public static void CarInfo(Car car)
        {
            Console.WriteLine($"  {car.Name} has current speed {car.SpeedPerSec / 1000}km/h and has driven {car.Distance}m");
        }

        public static int Obstacle(Car car)
        {
            Random random = new Random();
            int number = random.Next(0, 50);
            int oldSpeed = car.SpeedPerSec;

            if (number == 25) // 1/50 chance
            {
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} is out of fuel. The car stops for 30 seconds to refuel...");
                car.SpeedPerSec = 0;
                Thread.Sleep(30000);
                car.SpeedPerSec = oldSpeed;
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} has filled the car with fuel and continues the race!");
            }
            else if (number == 10 || number == 40) // 2/50 chance
            {
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} car needs a tire change. 20 second break...");
                car.SpeedPerSec = 0;
                Thread.Sleep(20000);
                car.SpeedPerSec = oldSpeed;
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} has changed tire and continues the race!");

            }
            else if (number == 5 || number == 15 || number == 25 || number == 35 || number == 45) // 5/50 chance
            {
                Console.WriteLine($"\n  ►► A bird hit the windshield. {Thread.CurrentThread.Name} needs to stop for 10 second to clean the windshield");
                car.SpeedPerSec = 0;
                Thread.Sleep(10000);
                car.SpeedPerSec = oldSpeed;
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} has cleaned the windshield and continues the race!");
            }
            else if (number == 1 || number == 9 || number == 11 || number == 19 || number == 21 || // 10/50 chance
                number == 29 || number == 31 || number == 39 || number == 41 || number == 49)
            {
                Console.WriteLine($"\n  ►► {Thread.CurrentThread.Name} gets engine failure and speed is reduced by 1km/h");
                car.SpeedPerSec = car.SpeedPerSec - 1000;
            }
            return car.SpeedPerSec;
        }
    }
}

