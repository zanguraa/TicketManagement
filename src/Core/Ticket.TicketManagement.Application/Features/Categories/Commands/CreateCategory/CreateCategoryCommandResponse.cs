using Ticket.TicketManagement.Application.Responses;

namespace Ticket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base() { }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}
