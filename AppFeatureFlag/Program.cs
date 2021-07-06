using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFeatureFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
             webBuilder.ConfigureAppConfiguration(config =>
             {
                 var settings = config.Build();
                 config.AddAzureAppConfiguration(options =>
                     options.Connect("Endpoint=https://shubham.azconfig.io;Id=s/2x-l0-s0:hvDF8PMQrltTXvj8olTY;Secret=7FSNxtRBFC51lVhSLTto5HfA+H5HwPhVBqXMxs8jDIc=").UseFeatureFlags());
             }).UseStartup<Startup>());
    }
}
