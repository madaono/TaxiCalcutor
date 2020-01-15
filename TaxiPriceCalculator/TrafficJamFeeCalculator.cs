using System.Linq;
using TaxiPriceCalculator.Utils;

namespace TaxiPriceCalculator
{
    public static class TrafficJamFeeCalculator
    {
        public static int GetJamMinutes(float[] perSecDistance)
        {
            var totalJamMinutes = 0;
            var secondsOfMinute = 60;

            var startingTime = GetOverStartTimeStamp(perSecDistance);
            var distances = perSecDistance.ToList();

            distances.RemoveRange(0, startingTime);
            var speedsInMinutes = distances.ToList().ChunkBy(secondsOfMinute);
            foreach (var speedsInMinute in speedsInMinutes)
            {
                if (speedsInMinute.Count == secondsOfMinute && speedsInMinute.Sum() / secondsOfMinute < Config.SPEED_BASELINE)
                    totalJamMinutes += 1;
            }

            return totalJamMinutes;
        }

        public static int GetOverStartTimeStamp(params float[] speedsEachSecond)
        {
            var startDistance = (float) Config.STARTING_DISTRANCE;
            var endTime = 0;

            for (int i = 0; i < speedsEachSecond.Length; i++)
            {
                var distanceInSeconds = speedsEachSecond[i] / 60 / 60;
                startDistance -= distanceInSeconds;
                endTime++;
                if (startDistance <= 0)
                {
                    break;
                }
            }

            return endTime;
        }
    }
}