using LocationSpoting.Services;
using Microsoft.AspNetCore;

namespace LocationSpoting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DataRepository dtr = new DataRepository();
            //dtr.ReadFromFile("data.json");
            BuildWebHost(args).Run();
         
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:4000")
                .Build();
    }
}
