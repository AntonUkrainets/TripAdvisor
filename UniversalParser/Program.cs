using Csv.Core.Mapping;
using Csv.Core.Services;
using Csv.SharedKernel.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UniversalParser.Core.Logging;
using UniversalParser.Core.Services;
using UniversalParser.Data.Domain;
using UniversalParser.Data.Domain.Interfaces;
using UniversalParser.Data.Entities;
using UniversalParser.Data.Repositories;
using UniversalParser.Data.Repositories.Interfaces;
using UniversalParser.Data.Services;
using UniversalParser.Data.Services.Interfaces;
using UniversalParser.SharedKernel.DTO;
using UniversalParser.SharedKernel.Interfaces;

var host = CreateHostBuilder(default!).Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dataContext = services.GetRequiredService<DataContext>();
    dataContext.Database.EnsureCreated();

    var runner = services.GetRequiredService<ApplicationRunner>();

    await runner.RunAsync();
}

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                options.LogTo(_ => { }, LogLevel.None);
            });

            services.Configure<CsvOptions>(context.Configuration.GetSection(nameof(CsvOptions)));

            services.AddAutoMapper(typeof(TripModelMappingProfile));

            services
                .AddScoped<IDataPersistenceRepository<Trip>, DataPersistenceRepository<Trip>>()
                .AddScoped<IUnitOfWork<Trip>, UnitOfWork<Trip>>()
                .AddScoped<IParser<TripDto>, CsvParser>()
                .AddScoped<ICsvProcessingService, CsvProcessingService>()
                .AddScoped<IDataPersistenceService<Trip>, DataPersistenceService<Trip>>()
                .AddScoped<ICsvWriter, CsvWriter>()
                .AddScoped<ApplicationRunner>();

            services.AddSingleton<UniversalParser.SharedKernel.Interfaces.ILogger, ConsoleLogger>();

            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.None);
            });
        });