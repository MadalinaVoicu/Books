using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BooksWebApi
{
    /// <summary>
    /// SS: This class is the starting point of our application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// SS: The Main method is responsible for configuring and running the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // SS: Build() builds the web host. 
            // SS: Run() starts running the web host. => It will run the web app and will block the calling thread until the host shuts down.
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //SS: UseStartup specifies the startup type to be used by the web host.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
