using AutoMapper;
using Ticket.TicketManagement.Application.Features.Events;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Event, EventListVm>().ReverseMap();
        }
    }
}
