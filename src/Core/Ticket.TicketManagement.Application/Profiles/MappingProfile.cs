﻿using AutoMapper;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryDto>().ReverseMap();
            CreateMap<Event, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
        }
    }
}
