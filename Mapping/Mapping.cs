using System.Globalization;
using System;
using AutoMapper;
using clinics_api.Dtos;
using clinics_api.Models;

namespace clinics_api.Mappings {
    public class Mapping : Profile {
        public Mapping() {
            // SCHEDULING MAPPING
            CreateMap<Scheduling, SchedulingDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => $"{x.FinalDate.Hours}:{x.FinalDate.Minutes}"))
            .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.FinalDate)))
            .ForMember(x => x.Date, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.Date, "dd/mm/yyyy", new CultureInfo("pt-BR"))));

            CreateMap<Scheduling, CreateSchedulingDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.Date, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.Date, "dd/mm/yyyy", new CultureInfo("pt-BR"))));

            CreateMap<Scheduling, UpdateSchedulingDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.Date, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.Date, "dd/mm/yyyy", new CultureInfo("pt-BR"))));

            CreateMap<Scheduling, SchedulingDetailsDto>()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => $"{x.InitialDate.Hours}:{x.InitialDate.Minutes}"))
            .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap()
            .ForMember(x => x.InitialDate, opt => opt.MapFrom(x => TimeSpan.Parse(x.InitialDate)))
            .ForMember(x => x.Date, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.Date, "dd/mm/yyyy", new CultureInfo("pt-BR"))));

            // EXAM MAPPING
            CreateMap<Exam, ExamDto>().ReverseMap();

            CreateMap<Exam, CreateExamDto>()
            .ForMember(x => x.Duration, opt => opt.MapFrom(x => $"{x.Duration.Hours}:{x.Duration.Minutes}"))
            .ReverseMap()
            .ForMember(x => x.Duration, opt => opt.MapFrom(x => TimeSpan.Parse(x.Duration)));

            // ADDRESS MAPPING
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();

            // CLIENT MAPPING
            CreateMap<Client, ClientDto>()
            .ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject))
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.BirthDate.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap().ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject))
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.BirthDate, "dd/mm/yyyy", new CultureInfo("pt-BR"))));

            CreateMap<Client, CreateClientDto>().ReverseMap();

            CreateMap<Client, ClientDetailsDto>()
            .ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject))
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(
                x => x.BirthDate.ToString("dd/mm/yyyy", new CultureInfo("pt-BR"))))
            .ReverseMap()
            .ForMember(x => x.AddressObject, opt => opt.MapFrom(x => x.AddressObject))
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(
                x => DateTime.ParseExact(x.BirthDate, "dd/mm/yyyy", new CultureInfo("pt-BR"))));
        }
    }
}