using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace worker
{
    public class Config
    {
        public static string SectionName = "PublisherApi";
        public string uri { get; set; }
    }

    public static class ConfigExtensions{

       public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new Config();
            configuration.Bind(Config.SectionName, config);
            services.AddSingleton(config);
            services.AddHttpClient(Config.SectionName, c =>
            {
                c.BaseAddress = new Uri(config.uri);
            });
        }
    }
}