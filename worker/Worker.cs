using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using worker.Services;

namespace worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PubliserApiService service;

        public Worker(ILogger<Worker> logger, PubliserApiService service)
        {
            _logger = logger;
            this.service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken )
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                  var result =  await service.GetData();
                foreach (var item in result)
                {
                    _logger.LogInformation($"{item.Name} - {item.Old} ...!", DateTimeOffset.Now);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

       
    }
}
