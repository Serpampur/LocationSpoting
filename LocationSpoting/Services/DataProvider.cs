using LocationSpoting.Models;
using System.Text.Json;

namespace LocationSpoting.Services;

public class DataProvider : IDataProvider
{
    private const string _dataDir = "AppData";
    private const string _fileName = "data.json";

    private readonly IHostEnvironment? _hostostEnvironment;
    public DataProvider(IHostEnvironment hostEnvironment)
    {
        _hostostEnvironment = hostEnvironment;
    }
    public List<Data>? ReadFromFile()
    {
        string path = Path.Combine(_hostostEnvironment.ContentRootPath, _dataDir, _fileName);
        string jsonString = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Data>>(jsonString);
    }

}