using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(d => d.Color, o => o.MapFrom<TicketColorResolver>());
            CreateMap<TicketDto, Ticket>();    
        }
    }
}