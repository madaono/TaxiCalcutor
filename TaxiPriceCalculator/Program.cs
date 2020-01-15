using System;
using System.Linq;

namespace TaxiPriceCalculator
{
    static class Program
    {
        static void Main(string[] args)
        {
            var trip = new Trip(2 + 2 + 0.5f + 1.25f)
            {
                SpeedsPerSecond = Enumerable.Repeat(80f, 90).Concat(Enumerable.Repeat(120f, 60))
                    .Concat(Enumerable.Repeat(30f, 60)).Concat(Enumerable.Repeat(90f, 50)).ToArray()
            };
            var fee = new TaxiPriceCalculatorService(trip).CalculateTotalFee();
            Console.WriteLine($"Hello Taxi Price Calculator! Your cost would be: {fee}");
        }
    }
}