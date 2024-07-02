using MediatR;

namespace Ticket.TicketManagement.Application.Features.Orders.Queries
{
    public class PagedOrdersFotMonthVm
    {
        public int Count { get; set; }
        public ICollection<OrdersForMonthDto>? OrdersForMonth { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
