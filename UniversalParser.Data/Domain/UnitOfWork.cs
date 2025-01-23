using UniversalParser.Data.Domain.Interfaces;
using UniversalParser.Data.Repositories;
using UniversalParser.Data.Repositories.Interfaces;

namespace UniversalParser.Data.Domain;

public class UnitOfWork<T>(DataContext dataContext) : IUnitOfWork<T>, IDisposable
    where T : class
{
    private IDataPersistenceRepository<T>? _datas;
    private bool _disposed;

    public IDataPersistenceRepository<T> Datas => _datas ??= new DataPersistenceRepository<T>(dataContext);

    public async Task SaveAsync(CancellationToken stoppingToken)
    {
        await dataContext.SaveChangesAsync(stoppingToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                dataContext.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}