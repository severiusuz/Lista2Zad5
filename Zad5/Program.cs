using System;
using System.Threading;

namespace Zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int[] values = new int[100];
            for (int i = 0; i < 100; i++)
                values[i] = rand.Next(1000);
            var searchEngine = new SearchValue();

            int maxValue = int.MaxValue;
            int minValue = int.MinValue;

            var maxThread = new Thread(() => maxValue = searchEngine.SearchForMax(values));
            var minThread = new Thread(() => minValue = searchEngine.SearchForMin(values));

            maxThread.Start();
            minThread.Start();
            maxThread.Join();
            minThread.Join();

            Console.WriteLine("Max: " + maxValue);
            Console.WriteLine("Min: " + minValue);
            Console.ReadKey();
        }
    }
}
