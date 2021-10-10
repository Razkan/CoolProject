using System.Data.Common;
using System.Data.SQLite;
using BackendAPI.HostedService;
using Interfaces.Model;
using Interfaces.Model.Db;
using Library.Communication.Converter;
using Library.Service;
using Library.Service.Repository;
using Library.Service.Repository.Db.Databases;
using Library.Service.Repository.Db.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BackendAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseSetting = new DatabaseSetting();
            Configuration.GetSection("DatabaseSettings").Bind(databaseSetting);
            services.AddSingleton<IDatabaseSettings>(databaseSetting);
            services.AddScoped<IDatabaseContext, SqLiteDatabase>();
            services.AddScoped<DbConnection, SQLiteConnection>();

            services.AddHttpClient("client");
            services.AddScoped<IRemoteProcedureCall, RemoteProcedureCall>();
            services.AddScoped<IRepository, Repository>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddMvcOptions(option =>
                {
                    option.EnableEndpointRouting = false;
                })
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.Converters.Add(new InterfaceConverter_v2());
                });

            services.AddControllers();

            services.AddHostedService<URIsHostedService>();
            services.AddHostedService<DatabaseHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}