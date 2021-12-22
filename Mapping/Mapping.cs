using System;
using AutoMapper;
using clinics_api.Dtos;
using clinics_api.Models;

namespace clinics_api.Mappings {
    public class Mapping : Profile {
        public Mapping() {
            CreateMap<Scheduling, SchedulingDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.FinalDate)));

            CreateMap<Scheduling, CreateSchedulingDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.FinalDate)));

            CreateMap<Exam, ExamDto>().ReverseMap();

            CreateMap<Exam, CreateExamDto>()
            .ForMember(x => x.Duration, opt => opt.MapFrom(x => $"{x.Duration.Hours}:{x.Duration.Minutes}"))
            .ReverseMap()
            .ForMember(x => x.Duration, opt => opt.MapFrom(x => TimeSpan.Parse(x.Duration)));

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();

            CreateMap<Client, ClientDto>()
            .ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject))
            .ReverseMap().ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject));
            CreateMap<Client, CreateClientDto>().ReverseMap();
        }
    }
}