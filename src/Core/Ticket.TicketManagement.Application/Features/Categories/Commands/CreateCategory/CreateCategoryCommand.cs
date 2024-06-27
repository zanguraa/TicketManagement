using MediatR;
using Ticket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;

namespace Ticket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
