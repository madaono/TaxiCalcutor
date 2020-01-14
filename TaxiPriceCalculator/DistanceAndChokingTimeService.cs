using System.Linq;

namespace TaxiPriceCalculator
{
    public class DistanceAndChokingTimeService
    {
        public int TotalTime { get; set; }
        public float TotalDistance { get; set; }

        public DistanceAndChokingTimeService()
        {
        }

        public DistanceAndChokingTimeService(int totalTime, float totalDistance)
        {
            TotalTime = totalTime;
            TotalDistance = totalDistance;
        }

        public int GetCholkingTime(params float[] perSecDistance)
        {
            // we can get km/min and totalDistance and total time
            // we need to cut down the first 2km
//            120km/h = 0.03333333333
            var totalCholkingTime = 0;
            var fastSpeed = 120;
            float minCholkingSpeedPerSecond = (float)fastSpeed / 3600;
            var startingTime = GetOverStartTimeStamp(perSecDistance);
            var distances = perSecDistance.ToList();
            distances.RemoveRange(0, count: startingTime);
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < minCholkingSpeedPerSecond)
                {
                    totalCholkingTime += 1;
                }
            }

            return totalCholkingTime;
        }

        public static int GetOverStartTimeStamp(params float[] perSecDistance)
        {
            var startDistance = 2f;
            var endTime = 0;

            for (int i = 0; i < perSecDistance.Length; i++)
            {
                startDistance -= perSecDistance[i];
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