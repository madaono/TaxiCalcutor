using System;

namespace TaxiPriceCalculator
{
    public class TaxiPriceCalculatorService
    {
        // todo take all this field to main or config
        public double TotalFee { set; get; } = 0;

        public int CalculateTotalFee(float totalDistance, int cholkingTime = 0)
        {
            if (totalDistance <= 0)
                return 0;
            
            if (totalDistance <= TaxiPriceCalculatorConfig.STARTING_DISTRANCE)
                return TaxiPriceCalculatorConfig.STARTING_FEE;

            // all the logic will be done in ChokingTimeService
//            var chokingTime = ChokingTimeService.GetCholkingTime();

            return (int) AddStartFee().AddExtraOilFee().AddDistanceFee(totalDistance).AddChokingFee(cholkingTime).TotalFee;
        }

        public TaxiPriceCalculatorService AddStartFee()
        {
            TotalFee += TaxiPriceCalculatorConfig.STARTING_FEE;
            return this;
        }

        public TaxiPriceCalculatorService AddDistanceFee(float distance)
        {
            TotalFee += (int) Math.Ceiling(distance - TaxiPriceCalculatorConfig.STARTING_DISTRANCE) * TaxiPriceCalculatorConfig.PRICE;
            return this;
        }

        public TaxiPriceCalculatorService AddExtraOilFee()
        {
            TotalFee += TaxiPriceCalculatorConfig.EXTRA_OIL_FEE;
            return this;
        }

        public TaxiPriceCalculatorService AddChokingFee(int minutes)
        {
            TotalFee += minutes * TaxiPriceCalculatorConfig.CHOKING_FEE;
            return this;
        }
    }
}