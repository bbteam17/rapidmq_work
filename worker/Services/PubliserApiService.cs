using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace worker.Services
{
    public class PubliserApiService
    {
        private readonly ILogger<PubliserApiService> logger;
        private readonly Config config;
        private readonly IHttpClientFactory clientFactory;


        public PubliserApiService(ILogger<PubliserApiService> logger ,Config config , IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.config = config;
            this.clientFactory = clientFactory;
        }

        public async Task<List<User>> GetData() {
            try
            {
                logger.LogInformation($"try call publisher api  {config.uri}");
                var client = clientFactory.CreateClient(Config.SectionName);
                var response = await client.GetAsync("User");
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(result);
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }
            return new List<User>();
        }
    }
}
