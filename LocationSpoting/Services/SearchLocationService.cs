using LocationSpoting.Hellper;
using LocationSpoting.Models;

namespace LocationSpoting.Services
{
    public class SearchLocationService: ISearchLocationService
    {
        private readonly IDataProvider _dataProvider;

        public SearchLocationService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;   
        }

        public SearchResponse? Search(SearchLocationRequest searchRequest)
        {
            var data = _dataProvider.ReadFromFile();

            if (data == null) 
            {
                return null;
            }

            var _dataRepository = new DataRepository(data);    
            var filteredData = _dataRepository.Search(searchRequest.Name);
            var results = CreateAndCalculateResults(filteredData, searchRequest.Position.Latitude, searchRequest.Position.Longitude, searchRequest.Name);

            return CreateSearchResponse(results, filteredData.Count(), _dataRepository.Count());
        }

        private SearchResponse CreateSearchResponse(List<DistanceResult> distanceResult,int totalHits, int totalDocuments)
        {
            return new SearchResponse()
            {
                TotalHits = totalHits,
                TotalDocuments = totalDocuments,
                Results = distanceResult
            };
        }

        private List<DistanceResult> CreateAndCalculateResults(List<Data> data, double geoLat, double geoLng, string searchName)
        {
            IDistanceCalculator _distanceCalculator = new DistanceCalculator();
            ISearchScoreMetric _scoreCalculation = new SearchScoreMetric();
            var results = new List<DistanceResult>();
            
            foreach( var result in data)
            {
               
                if (result != null)
                {
                    double distance = _distanceCalculator.CalculateDistance(geoLat, result.Position?.Latitude, geoLng, result.Position?.Longitude);
                    double score = _scoreCalculation.CalculateScore(result.Name,searchName);
                    DistanceResult distanceResult = CreateDistanceResult(result, distance, score);
                    results.Add(distanceResult);
                }
            }
            return results;
        }

        private static DistanceResult CreateDistanceResult(Data data, double distance, double score)
        {
            return new DistanceResult
            {
                Id = data.Id,
                Name = data.Name,
                Position = new Position
                {
                    Latitude = data.Position!.Latitude,
                    Longitude = data.Position.Longitude,
                },
                Distance = $"{Math.Round(distance, 2)}km",
                Score = score,
            };
        }

      


    }
}
