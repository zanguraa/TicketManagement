using Microsoft.EntityFrameworkCore;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaserRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}
