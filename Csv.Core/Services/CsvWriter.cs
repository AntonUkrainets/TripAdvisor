using Csv.SharedKernel.Configurations;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using System.Text;
using UniversalParser.SharedKernel.DTO;
using UniversalParser.SharedKernel.Interfaces;

namespace Csv.Core.Services;

public class CsvWriter(IOptions<CsvOptions> options) : ICsvWriter
{
    private readonly CsvConfiguration _config = CsvHelperConfigProvider.GetConfiguration();
    private readonly CsvOptions _options = options.Value;

    public async Task CreateHeadersAsync()
    {
        if (File.Exists(_options.DuplicateFilePath))
            return;

        using var writer = new StreamWriter(_options.DuplicateFilePath, false, Encoding.UTF8);
        using var csvWriter = new CsvHelper.CsvWriter(writer, _config);

        csvWriter.WriteHeader<TripDto>();
        await csvWriter.NextRecordAsync();
    }

    public async Task AppendDuplicateAsync(TripDto record)
    {
        using var writer = new StreamWriter(_options.DuplicateFilePath, true, Encoding.UTF8);
        using var csv = new CsvHelper.CsvWriter(writer, _config);

        csv.WriteRecord(record);
        await csv.NextRecordAsync();
    }
}