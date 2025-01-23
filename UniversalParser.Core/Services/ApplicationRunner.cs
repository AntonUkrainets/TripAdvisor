using AutoMapper;
using Csv.SharedKernel.Configurations;
using Microsoft.Extensions.Options;
using UniversalParser.Data.Entities;
using UniversalParser.Data.Services.Interfaces;
using UniversalParser.SharedKernel.Interfaces;

namespace UniversalParser.Core.Services;

public class ApplicationRunner(
    IOptions<CsvOptions> options,
    ICsvProcessingService csvProcessingService,
    IDataPersistenceService<Trip> dataPersistenceService,
    ICsvWriter csvWriter,
    IMapper mapper,
    ILogger logger
)
{
    private readonly CsvOptions _options = options.Value;

    public async Task RunAsync()
    {
        try
        {
            await csvWriter.CreateHeadersAsync();

            var trips = new List<Trip>();
            foreach (var record in csvProcessingService.ProcessCsv(_options.FilePath))
            {
                var trip = mapper.Map<Trip>(record);

                if (trips.Any(d => d.TpepPickupDatetime == trip.TpepPickupDatetime && d.TpepDropoffDatetime == trip.TpepDropoffDatetime && d.PassengerCount == trip.PassengerCount))
                {
                    await csvWriter.AppendDuplicateAsync(record);
                }
                else
                {
                    trips.Add(trip);
                }
            }

            if (trips.Count == 0)
                return;

            await dataPersistenceService.SaveDataAsync(trips);
        }
        catch (Exception ex)
        {
            logger.LogError("An error occurred during execution.", ex);
        }
    }
}