using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Interfaces.Model.Book;
using Interfaces.Model.Db;
using Library;
using Library.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendAPI.HostedService
{
    public class DatabaseHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            TrackedLog.Information("Start database", async () =>
            {
                await database.RunAsync();

                var spellBooks = new List<ISpellBook>
                {
                    SpellBooks.GetBookOfLight(),
                    SpellBooks.GetBookOfDarkness(),
                    SpellBooks.GetBookOfCreation(),
                    SpellBooks.GetBookOfDestruction(),
                    SpellBooks.GetBookOfAir(),
                    SpellBooks.GetBookOfWater(),
                    SpellBooks.GetBookOfFire(),
                    SpellBooks.GetBookOfEarth(),
                    SpellBooks.GetBookOfEssence(),
                    SpellBooks.GetBookOfIllusion(),
                    SpellBooks.GetBookOfNecromancy()
                };

                var tasks = spellBooks.Select(book => Task.Run(async () => await database.InsertAsync(book), cancellationToken)).ToList();
                Task.WhenAll(tasks).Wait(cancellationToken);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}