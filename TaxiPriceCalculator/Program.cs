using System;

namespace TaxiPriceCalculator
{
    static class Program
    {
        static void Main(string[] args)
        {
            var distanceAndTimeService = new DistanceAndChokingTimeService(20, 60f);
            var cholkingTime = distanceAndTimeService.GetCholkingTime(0.03f, 0.06f);
            var fee = new TaxiPriceCalculatorService().CalculateTotalFee(distanceAndTimeService.TotalDistance, cholkingTime);
            Console.WriteLine($"Hello Taxi Price Calculator! Your cost would be: {fee}");
        }
    }
}