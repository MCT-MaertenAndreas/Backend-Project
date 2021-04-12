using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API.IMDB
{
    public class Program
    {
        public static readonly string Title = "Backend Project";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
