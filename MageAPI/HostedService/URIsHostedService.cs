using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Shared;
using Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MageAPI.HostedService
{
    public class URIsHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public URIsHostedService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var rpc = scope.ServiceProvider.GetRequiredService<IRemoteProcedureCall>();

            TrackedLog.Information("Sending URIs to tracker", 3, () =>
            {
                var mage_host = Environment.GetEnvironmentVariable("MAGE_HOST") ?? "localhost:9000";
                var tasks = new List<Task>
                {
                    rpc.Register<IArcanum>(new Uri($"http://{mage_host}/arcanum/all"))
                };

                Task.WhenAll(tasks).Wait(cancellationToken);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}