namespace UniversalParser.Data.Services.Interfaces;

public interface IDataPersistenceService<T>
{
    Task SaveDataAsync(IEnumerable<T> data);
}