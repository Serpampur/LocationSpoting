using LocationSpoting.Models;

namespace LocationSpoting.Services
{
    public interface IDataProvider
    {
        List<Data>? ReadFromFile();
    }
}
