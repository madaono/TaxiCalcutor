using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class TaxiPriceCalculatorSystemSpec
    {
        [Fact]
        void should_return_correct_fee_given_distance_time_is_in_starting_distance()
        {
            var distanceAndTimeService = new DistanceAndChokingTimeService(20, 2f);
            var cholkingTime = distanceAndTimeService.GetCholkingTime(0.03f, 0.06f);
            var fee = new TaxiPriceCalculatorService().CalculateTotalFee(distanceAndTimeService.TotalDistance, cholkingTime);
            Assert.Equal(TaxiPriceCalculatorConfig.STARTING_FEE, fee);
        }
        
        [Fact]
        void should_return_correct_fee_given_distance_time_is_not_in_starting_distance()
        {
            var distanceAndTimeService = new DistanceAndChokingTimeService(20, 2.02f);
            var cholkingTime = distanceAndTimeService.GetCholkingTime(2f, 0.02f);
            var fee = new TaxiPriceCalculatorService().CalculateTotalFee(distanceAndTimeService.TotalDistance, cholkingTime);
            
            Assert.Equal(6, fee);
        }
    }
}