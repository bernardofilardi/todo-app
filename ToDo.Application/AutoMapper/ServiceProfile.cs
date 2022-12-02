using AutoMapper;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Extensions;
using ToDo.Domain.Entities;

namespace ToDo.Application.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Item, ItemResponseDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToApplicationTime()));
        }
    }
}
