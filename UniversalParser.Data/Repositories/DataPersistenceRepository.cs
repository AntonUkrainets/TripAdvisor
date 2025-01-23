using EFCore.BulkExtensions;
using UniversalParser.Data.Domain;
using UniversalParser.Data.Repositories.Interfaces;

namespace UniversalParser.Data.Repositories;

public class DataPersistenceRepository<T>(DataContext dataContext) : IDataPersistenceRepository<T>
    where T : class
{
    public async Task BulkDataAsync(T[] datas, CancellationToken stoppingToken = default)
    {
        var bulkConfig = new BulkConfig
        {
            BatchSize = datas.Length
        };

        await dataContext.BulkInsertAsync(datas, bulkConfig, cancellationToken: stoppingToken);
    }
}