using AutoMapper;
using TodoApi.Contracts;
using TodoApi.Models;

namespace TodoApi.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateTodoRequest, Todo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore());

            CreateMap<UpdateTodoRequest, Todo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore());
        }
    }
}