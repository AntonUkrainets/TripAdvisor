using UniversalParser.SharedKernel.DTO;
using UniversalParser.SharedKernel.Interfaces;

namespace Csv.Core.Services;

public class CsvProcessingService(IParser<TripDto> csvParser, ILogger logger) : ICsvProcessingService
{
    public IEnumerable<TripDto> ProcessCsv(string filePath)
    {
        if (!File.Exists(filePath))
        {
            logger.LogError($"File not found: {filePath}");
            return [];
        }

        if (!csvParser.CanParse(filePath))
        {
            logger.LogError("Provided file is not a valid CSV.");
            return [];
        }

        return csvParser.Parse(filePath);
    }
}