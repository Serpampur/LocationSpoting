using LocationSpoting.Models;

namespace LocationSpoting.Services
{
    public class DataRepository: IDataRepository
    {
        private readonly List<Data> _data;

        public DataRepository(List<Data> data)
        {
            _data = data;
        }

        public int Count() 
        {
            return _data.Count;
        }
        /// <summary>
        /// Search by name pattern
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List filtered data</returns>
        public List<Data> Search(string name)
        {
            return _data.FindAll(x => x.Name.ToUpperInvariant().Contains(name.ToUpper()));
        }

    }
}