using MediatR;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

namespace Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {

    }
}
