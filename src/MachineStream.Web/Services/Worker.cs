using System;
using System.Threading;
using System.Threading.Tasks;
using MachineStream.Web.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MachineStream.Web.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider services,
            ILogger<Worker> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is working.");

            using var scope = Services.CreateScope();
            var websocketClient =
                scope.ServiceProvider
                    .GetRequiredService<IWebsocketClient>();

            await websocketClient.ConnectAndReceive(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}