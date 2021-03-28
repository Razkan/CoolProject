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

                {
                    var spellBooks = new List<ICoreSpellBook>
                    {
                        CoreSpellBooks.GetBookOfLight(),
                        CoreSpellBooks.GetBookOfDarkness(),
                        CoreSpellBooks.GetBookOfCreation(),
                        CoreSpellBooks.GetBookOfDestruction(),
                        CoreSpellBooks.GetBookOfAir(),
                        CoreSpellBooks.GetBookOfWater(),
                        CoreSpellBooks.GetBookOfFire(),
                        CoreSpellBooks.GetBookOfEarth(),
                        CoreSpellBooks.GetBookOfEssence(),
                        CoreSpellBooks.GetBookOfIllusion(),
                        CoreSpellBooks.GetBookOfNecromancy()
                    };

                    var tasks = spellBooks.Select(book => Task.Run(async () => await database.InsertAsync(book), cancellationToken)).ToList();
                    Task.WhenAll(tasks).Wait(cancellationToken);
                }

                {
                    var spellBooks = new List<IArcanaSpellBook>
                    {
                        ArcanaSpellBooks.GetNobility(),
                    };

                    var tasks = spellBooks.Select(book => Task.Run(async () => await database.InsertAsync(book), cancellationToken)).ToList();
                    Task.WhenAll(tasks).Wait(cancellationToken);
                }
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}