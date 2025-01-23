using AutoMapper;
using UniversalParser.Data.Entities;
using UniversalParser.SharedKernel.DTO;

namespace Csv.Core.Mapping;

public class TripModelMappingProfile : Profile
{
    public TripModelMappingProfile()
    {
        CreateMap<TripDto, Trip>()
            .ForMember(dest => dest.StoreAndFwdFlag, opt => opt.MapFrom(src =>
                src.StoreAndFwdFlag == "N" ? "No" :
                src.StoreAndFwdFlag == "Y" ? "Yes" : src.StoreAndFwdFlag))
            .ForMember(dest => dest.TpepPickupDatetime, opt => opt.MapFrom(src =>
                TimeZoneInfo.ConvertTimeToUtc(src.TpepPickupDatetime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"))))
            .ForMember(dest => dest.TpepDropoffDatetime, opt => opt.MapFrom(src =>
                TimeZoneInfo.ConvertTimeToUtc(src.TpepDropoffDatetime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"))));
    }
}