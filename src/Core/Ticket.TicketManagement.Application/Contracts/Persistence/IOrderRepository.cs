using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
