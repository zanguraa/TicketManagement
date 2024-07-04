using Microsoft.EntityFrameworkCore;
using Moq;
using Ticket.TicketManagement.Application.Contracts;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Persistence.IntegrationTests
{
    public class TicketDbContextTests
    {
        private readonly TicketDbContext _ticketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _ticketDbContext = new TicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _ticketDbContext.Events.Add(ev);
            await _ticketDbContext.SaveChangesAsync();

            // ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}