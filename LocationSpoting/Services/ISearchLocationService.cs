using LocationSpoting.Models;

namespace LocationSpoting.Services
{
    public interface ISearchLocationService
    {
        SearchResponse? Search(SearchLocationRequest searchRequest);
    }
}
