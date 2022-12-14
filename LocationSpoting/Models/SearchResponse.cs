namespace LocationSpoting.Models
{
    public class SearchResponse
    {
        public int TotalHits { get; set; }
        public int TotalDocuments { get; set; }
        public IEnumerable<DistanceResult>? Results { get; set; }
    }
}
