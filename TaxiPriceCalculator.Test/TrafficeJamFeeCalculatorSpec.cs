using System.Linq;
using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class TrafficeJamFeeCalculatorSpec
    {
        [Fact]
        void should_return_0_jam_minute_given_distance_time_is_in_starting_distance()
        {
            var startingspeeds = Enumerable.Repeat(80f, 90);
            var jamMinutes = TrafficJamFeeCalculator.GetJamMinutes(startingspeeds.ToArray());
            Assert.Equal(0, jamMinutes);
        }

        [Fact]
        void should_return_correct_jam_minutes_given_distance_is_not_in_starting_distance()
        {
            var startingspeeds = Enumerable.Repeat(80, 90);
            var normalSpeeds = Enumerable.Repeat(130, 60).Concat(Enumerable.Repeat(80, 60));
            var totalSpeeds = startingspeeds.Concat(normalSpeeds);
            var jamMinutes = TrafficJamFeeCalculator.GetJamMinutes(totalSpeeds.Select(i => (float) i).ToArray());

            Assert.Equal(1, jamMinutes);
        }

        [Fact]
        void should_return_correct_jam_minutes_given_distance_time_is_not_in_starting_distance_and_less_than_a_minute()
        {
            var startingspeeds = Enumerable.Repeat(80, 90);
            var normalSpeeds = Enumerable.Repeat(130, 60).Concat(Enumerable.Repeat(80, 60)).Concat(Enumerable.Repeat(80, 20));
            var totalSpeeds = startingspeeds.Concat(normalSpeeds);
            var jamMinutes = TrafficJamFeeCalculator.GetJamMinutes(totalSpeeds.Select(i => (float) i).ToArray());

            Assert.Equal(1, jamMinutes);
        }
    }
}