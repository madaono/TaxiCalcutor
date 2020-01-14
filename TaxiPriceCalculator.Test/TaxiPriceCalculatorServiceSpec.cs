using Xunit;

namespace TaxiPriceCalculator.Test
{
    public class TaxiPriceCalculatorServiceSpec
    {
        [Fact]
        void should_return_starting_fee_when_distance_is_lower_than_starting_distance__kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService();
            var cost = taxiPriceCalculator.CalculateTotalFee(2);
            Assert.Equal(3, cost);
        }

        [Fact]
        void should_return_correct_fee_yuan_when_distance_is_over_starting_distance_kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService();
            var cost = taxiPriceCalculator.CalculateTotalFee(2.1f);
            Assert.Equal(5, cost);
        }

        [Fact]
        void should_return_0_yuan_when_distance_is_0_kilometer()
        {
            var taxiPriceCalculator = new TaxiPriceCalculatorService();
            var cost = taxiPriceCalculator.CalculateTotalFee(0);
            Assert.Equal(0, cost);
        }

        [Fact]
        void should_return_correct_fee_when_over_base_distance_and_give_choking_minutes()
        {
            var taxiPriceCaluator = new TaxiPriceCalculatorService();
            var cost = taxiPriceCaluator.CalculateTotalFee(2.5f, 20);
            Assert.Equal(25, cost);
        }
        
        [Fact]
        void should_return_correct_fee_when_not_over_base_distance_and_give_choking_minutes()
        {
            var taxiPriceCaluator = new TaxiPriceCalculatorService();
            var cost = taxiPriceCaluator.CalculateTotalFee(2.0f, 20);
            Assert.Equal(3, cost);
        }
    }
}