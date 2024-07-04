using Microsoft.EntityFrameworkCore;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaserRepository<Event>, IEventRepository
    {
        public EventRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = await _dbContext.Events.AnyAsync(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return !matches;
        }

        public async Task<Event> AddAsync(Event @event)
        {
            await _dbContext.Events.AddAsync(@event);
            await _dbContext.SaveChangesAsync();
            //await _dbContext.SaveChangesAsync();
            return @event;
        }
    }
}
