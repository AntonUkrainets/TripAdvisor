using UniversalParser.SharedKernel.DTO;

namespace UniversalParser.SharedKernel.Interfaces;

public interface ICsvProcessingService
{
    IEnumerable<TripDto> ProcessCsv(string filePath);
}