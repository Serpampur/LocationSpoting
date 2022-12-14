namespace LocationSpoting.Models
{
    public class DistanceResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Position? Position { get; set; }
        public string? Distance { get; set; }
        public double Score { get; set; }
    }
}
