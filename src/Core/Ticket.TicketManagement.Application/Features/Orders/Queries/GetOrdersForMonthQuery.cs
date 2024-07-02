using MediatR;

namespace Ticket.TicketManagement.Application.Features.Orders.Queries
{
    public class GetOrdersForMonthQuery : IRequest<PagedOrdersFotMonthVm>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
