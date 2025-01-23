using UniversalParser.Data.Repositories.Interfaces;

namespace UniversalParser.Data.Domain.Interfaces;

public interface IUnitOfWork<T>
{
    IDataPersistenceRepository<T> Datas { get; }

    Task SaveAsync(CancellationToken stoppingToken);
}