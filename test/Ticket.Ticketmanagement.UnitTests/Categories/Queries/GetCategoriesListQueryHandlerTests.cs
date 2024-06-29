using AutoMapper;
using Moq;
using Shouldly;
using Ticket.Ticketmanagement.UnitTests.Mocks;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using Ticket.TicketManagement.Application.Profiles;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.Ticketmanagement.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();
            result.Count.ShouldBe(4);
        }
    }
}
