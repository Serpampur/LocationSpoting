namespace LocationSpoting.Hellper
{
    public interface ISearchScoreMetric
    {
        int CalculateScore(string orginName, string searchName);
    }
}