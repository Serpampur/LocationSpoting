namespace LocationSpoting.Hellper
{   
       public interface IDistanceCalculator
        {
            /// <summary>
            /// Calculates distance between two coordinates.
            /// </summary>
            /// <param name="latDegree1"></param>
            /// <param name="latDegree2"></param>
            /// <param name="lonDegree1"></param>
            /// <param name="lonDegree2"></param>
            /// <returns>The distance.</returns>
            double CalculateDistance(double? latDegree1, double? latDegree2, double? lonDegree1, double? lonDegree2);
        }
  
}
