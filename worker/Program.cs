using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using worker.Services;

namespace worker
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            
            return Host.CreateDefaultBuilder(args)
                 
                  .ConfigureServices((hostContext, services) =>
                  {
                      IConfiguration configuration = hostContext.Configuration;
                      services.AddConfiguration(configuration);
                      services.AddHostedService<Worker>();
                      services.AddSingleton<PubliserApiService>();
                  });
        }

    }
}
