using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendAPI.HostedService
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
                var tasks = new List<Task>
                {
                    rpc.Register<ISpellBook>(new Uri("http://localhost:9000/book/all")),

                    //rpc.Register<IBookOfLight>(new Uri("http://localhost:9000/book/light")),
                    //rpc.Register<IBookOfDarkness>(new Uri("http://localhost:9000/book/darkness")),
                    //rpc.Register<IBookOfCreation>(new Uri("http://localhost:9000/book/creation")),
                    //rpc.Register<IBookOfDestruction>(new Uri("http://localhost:9000/book/destruction")),
                    //rpc.Register<IBookOfFire>(new Uri("http://localhost:9000/book/fire")),
                    //rpc.Register<IBookOfWater>(new Uri("http://localhost:9000/book/water")),
                    //rpc.Register<IBookOfEarth>(new Uri("http://localhost:9000/book/earth")),
                    //rpc.Register<IBookOfAir>(new Uri("http://localhost:9000/book/air")),
                    //rpc.Register<IBookOfEssence>(new Uri("http://localhost:9000/book/essence")),
                    //rpc.Register<IBookOfIllusion>(new Uri("http://localhost:9000/book/illusion")),
                    //rpc.Register<IBookOfNecromancy>(new Uri("http://localhost:9000/book/necromancy"))
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