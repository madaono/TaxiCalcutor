using System;

namespace TaxiPriceCalculator
{
    public class TaxiPriceCalculatorService
    {
        private readonly Trip _trip;

        public TaxiPriceCalculatorService(Trip trip)
        {
            _trip = trip;
        }

        double TotalFee { set; get; }

        public int CalculateTotalFee()
        {
            if (_trip.Distance <= 0)
                return 0;

            if (_trip.Distance <= Config.STARTING_DISTRANCE)
                return Config.STARTING_FEE;

            return (int) AddStartFee().AddExtraOilFee().AddDistanceFee().AddJamFee().TotalFee;
        }

        TaxiPriceCalculatorService AddStartFee()
        {
            TotalFee += Config.STARTING_FEE;
            return this;
        }

        TaxiPriceCalculatorService AddDistanceFee()
        {
            TotalFee += (int) Math.Ceiling(_trip.Distance - Config.STARTING_DISTRANCE) * Config.PRICE;
            return this;
        }

        TaxiPriceCalculatorService AddExtraOilFee()
        {
            TotalFee += Config.EXTRA_OIL_FEE;
            return this;
        }

        TaxiPriceCalculatorService AddJamFee()
        {
            var minutes = TrafficJamFeeCalculator.GetJamMinutes(_trip.SpeedsPerSecond);
            TotalFee += minutes * Config.TRAFFICE_JAM_FEE;
            return this;
        }

        TaxiPriceCalculatorService AddNightFee()
        {
            var distance = TrafficJamFeeCalculator.GetNightDriveDistance();
            TotalFee += distance * Config.NIGHT_DRIVE_FEE;
            return this;
        }
    }
}