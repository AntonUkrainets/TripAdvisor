using Csv.Core.Mapping;
using Csv.SharedKernel.Configurations;
using CsvHelper;
using System.Text;
using UniversalParser.SharedKernel.DTO;
using UniversalParser.SharedKernel.Interfaces;

namespace Csv.Core.Services;

public class CsvParser : IParser<TripDto>
{
    public IEnumerable<TripDto> Parse(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        var config = CsvHelperConfigProvider.GetConfiguration();

        using var reader = new StreamReader(path, Encoding.UTF8);
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<DataCsvMapper>();

        while (csv.Read())
        {
            var record = csv.GetRecord<TripDto>();

            yield return record;
        }
    }

    public bool CanParse(string source)
    {
        return source.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);
    }
}