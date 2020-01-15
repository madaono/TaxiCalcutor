using System;
using System.Linq;
using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class TaxiPriceCalculatorServiceSpec
    {
        [Fact]
        void should_return_starting_fee_when_distance_is_lower_than_starting_distance__kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService(new Trip(2));
            var cost = taxiPriceCalculator.CalculateTotalFee();
            Assert.Equal(3, cost);
        }

        [Fact]
        void should_return_correct_fee_yuan_when_distance_is_over_starting_distance_kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService(new Trip(2.1f));
            var cost = taxiPriceCalculator.CalculateTotalFee();
            Assert.Equal(5, cost);
        }

        [Fact]
        void should_return_0_yuan_when_distance_is_0_kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService(new Trip(0));
            var cost = taxiPriceCalculator.CalculateTotalFee();
            Assert.Equal(0, cost);
        }

        [Fact]
        void should_return_correct_fee_when_has_traffic_jam()
        {
            var trip = new Trip(2 + 2 + 0.5f + 1.25f)
            {
                SpeedsPerSecond = Enumerable.Repeat(80f, 90).Concat(Enumerable.Repeat(120f, 60)).Concat(Enumerable.Repeat(30f, 60)).Concat(Enumerable.Repeat(90f, 50)).ToArray()
            };
            var taxiPriceCaluator = new TaxiPriceCalculatorService(trip);
            var cost = taxiPriceCaluator.CalculateTotalFee();
            Assert.Equal((3 + 4) + 1 + 1, cost);
        }

        [Fact]
        void should_return_correct_fee_when_drive_during_23_to_6_clock()
        {
            var trip =  new Trip()
            {
                Distance = 50,
                StartedAt = DateTime.Parse("23:00"),
                FinishedAt = DateTime.Parse("23:59")
            };
            var taxiPriceCalculator = new TaxiPriceCalculatorService(trip);
            var cost = taxiPriceCalculator.CalculateTotalFee();
            Assert.Equal(3+48+1, cost);
        }
    }
}