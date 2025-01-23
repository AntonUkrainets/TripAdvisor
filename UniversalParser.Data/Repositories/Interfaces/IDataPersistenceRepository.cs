namespace UniversalParser.Data.Repositories.Interfaces;

public interface IDataPersistenceRepository<T>
{
    Task BulkDataAsync(T[] datas, CancellationToken stoppingToken = default);
}