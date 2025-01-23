using UniversalParser.SharedKernel.DTO;

namespace UniversalParser.SharedKernel.Interfaces;

public interface ICsvWriter
{
    Task CreateHeadersAsync();

    Task AppendDuplicateAsync(TripDto record);
}