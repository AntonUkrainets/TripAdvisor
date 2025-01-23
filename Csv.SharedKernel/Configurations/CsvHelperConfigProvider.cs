using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Csv.SharedKernel.Configurations;

public static class CsvHelperConfigProvider
{
    public static CsvConfiguration GetConfiguration()
    {
        return new CsvConfiguration(new CultureInfo("en-US"))
        {
            Delimiter = ",",
            Mode = CsvMode.NoEscape,
            MissingFieldFound = null,
            TrimOptions = TrimOptions.Trim
        };
    }
}