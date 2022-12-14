using LocationSpoting.Models;

namespace LocationSpoting.Services
{
    /// <summary>
    /// Data repository
    /// </summary>
    public interface IDataRepository
    {
        int Count();

        List<Data> Search(string name);
    }
}
