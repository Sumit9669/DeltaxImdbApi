using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeltaxImdbApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // While developing locally, set your Heroku database connection string here and uncomment.
            // When ready to deploy to Heroku, remove this code.
            //DeltaxImdbApiConfiguration.ConnectionString = "PUT_HEROKU_DATABSE_CONNECTION_STRING_HERE";

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
