using System;
using System.Threading;

namespace StopwatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Subscribe to events
            stopwatch.OnStarted += message => Console.WriteLine(message);
            stopwatch.OnStopped += message => Console.WriteLine(message);
            stopwatch.OnReset += message => Console.WriteLine(message);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Press S to Start, T to Stop, R to Reset, Q to Quit:");
                char input = Console.ReadKey(true).KeyChar;

                switch (char.ToUpper(input))
                {
                    case 'S':
                        stopwatch.Start();
                        break;
                    case 'T':
                        stopwatch.Stop();
                        break;
                    case 'R':
                        stopwatch.Reset();
                        break;
                    case 'Q':
                        exit = true;
                        break;
                }

                if (stopwatch.GetElapsedTime().TotalSeconds > 0 || stopwatch.IsRunning)
                {
                    Console.Clear();
                    Console.WriteLine($"Elapsed Time: {stopwatch.GetElapsedTime()}");
                }

                if (stopwatch.IsRunning)
                {
                    Thread.Sleep(1000);
                    stopwatch.Tick();
                }
            }
        }
    }
}
