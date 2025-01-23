using UniversalParser.Data.Domain.Interfaces;
using UniversalParser.Data.Services.Interfaces;
using UniversalParser.SharedKernel.Interfaces;

namespace UniversalParser.Data.Services;

public class DataPersistenceService<T>(IUnitOfWork<T> unitOfWork, ILogger logger) : IDataPersistenceService<T>
    where T : class
{
    public async Task SaveDataAsync(IEnumerable<T> data)
    {
        try
        {
            await unitOfWork.Datas.BulkDataAsync(data.ToArray());

            logger.LogInfo($"Successfully saved {data.Count()} records to the database.");
        }
        catch (Exception ex)
        {
            logger.LogError("Error while saving data to the database.", ex);
            throw;
        }
    }
}