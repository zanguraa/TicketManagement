using MediatR;

namespace Ticket.TicketManagement.Application.Features.Events
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
