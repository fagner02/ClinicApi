using AutoMapper;
using clinics_api.Dtos;
using clinics_api.Models;

namespace clinics_api.Mappings {
    public class Mapping : Profile {
        public Mapping() {
            CreateMap<Scheduling, SchedulingDto>().ReverseMap();
            CreateMap<Scheduling, CreateSchedulingDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Exam, CreateExamDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, CreateClientDto>().ReverseMap();
        }
    }
}