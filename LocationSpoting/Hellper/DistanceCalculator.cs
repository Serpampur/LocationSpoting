namespace LocationSpoting.Hellper
{
    public class DistanceCalculator:IDistanceCalculator
    {
        private const double EarthRadius = 6371;

       
        public double CalculateDistance(double? latDegree1, double? latDegree2, double? lonDegree1, double? lonDegree2)
        {
            double lon1 = ConvertFromDegreeToRadian(lonDegree1);
            double lon2 = ConvertFromDegreeToRadian(lonDegree2);
            double lat1 = ConvertFromDegreeToRadian(latDegree1);
            double lat2 = ConvertFromDegreeToRadian(latDegree2);

         
            double distanceLongitude = lon2 - lon1;
            double distanceLatitude = lat2 - lat1;

            double a = Math.Pow(Math.Sin(distanceLatitude / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(distanceLongitude / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            return (c * EarthRadius);
        }

        private static double ConvertFromDegreeToRadian(double? locationInDegree)
        {
            if (locationInDegree != null)
            {
                return (double)locationInDegree * Math.PI / 180;
            }
            return 0;
        }
    }
}
