namespace LocationSpoting.Models
{
    public class SearchRequest
    {
        public string? ServiceName { get; set; }
        public GeoLocation? GeoLocation { get; set; }
    }
}