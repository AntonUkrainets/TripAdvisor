using Csv.Core.Csv;
using CsvHelper.Configuration;
using UniversalParser.SharedKernel.DTO;

namespace Csv.Core.Mapping;

public class DataCsvMapper : ClassMap<TripDto>
{
    public DataCsvMapper()
    {
        Map(m => m.TpepPickupDatetime).Name(CsvHeaders.TPEP_PICKUP_DATETIME);
        Map(m => m.TpepDropoffDatetime).Name(CsvHeaders.TPEP_DROPOFF_DATETIME);
        Map(m => m.PassengerCount).Name(CsvHeaders.PASSENGER_COUNT);
        Map(m => m.TripDistance).Name(CsvHeaders.TRIP_DISTANCE);
        Map(m => m.StoreAndFwdFlag).Name(CsvHeaders.STORE_AND_FWD_FLAG);
        Map(m => m.PULocationID).Name(CsvHeaders.PU_LOCATION_ID);
        Map(m => m.DOLocationID).Name(CsvHeaders.DO_LOCATION_ID);
        Map(m => m.FareAmount).Name(CsvHeaders.FARE_AMOUNT);
        Map(m => m.TipAmount).Name(CsvHeaders.TIP_AMOUNT);
    }
}