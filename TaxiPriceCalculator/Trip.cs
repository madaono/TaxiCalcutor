using System;

namespace TaxiPriceCalculator
{
    public class Trip
    {
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public float Distance { get; set; }
        public float[] SpeedsPerSecond { get; set; } = {};

        public Trip(float distance)
        {
            Distance = distance;
        }
    }
}