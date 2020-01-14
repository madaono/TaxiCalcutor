using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class ChokingTimeServiceSpec
    {

        [Theory]
        [InlineData(0.65f,0.66f,0.46f,0.55f,0.60f,0.79f)]
        void should_return_the_current_second_when_car_run_just_over_2_km(params float[] perSecDistance)
        {
            var time = DistanceAndChokingTimeService.GetOverStartTimeStamp(perSecDistance);
            Assert.Equal(4, time);
            
        }

        [Theory]
        [InlineData(0.6f, 0.66f, 0.46f, 0.55f, 0.60f, 0.79f, 0.030f, 0.03f, 0.02f, 0.01f)]
        void should_return_the_total_seconds_when_car_speed_is_less_than_120_km_per_hour(params float[] perSecDistance)
        {
            var service = new DistanceAndChokingTimeService();
            var chockingTime = service.GetCholkingTime(perSecDistance);
            Assert.Equal(4, chockingTime);
        }
        
        [Theory]
        [InlineData(0.01f, 0.01f, 0.01f, 0.01f, 0.01f, 0.03f, 0.02f, 0.01f)]
        void should_return_0_when_car_speed_is_less_than_120_km_per_hour_and_within_start_distance(params float[] perSecDistance)
        {
            var service = new DistanceAndChokingTimeService();
            var chockingTime = service.GetCholkingTime(perSecDistance);
            Assert.Equal(0, chockingTime);
        }
    }
}