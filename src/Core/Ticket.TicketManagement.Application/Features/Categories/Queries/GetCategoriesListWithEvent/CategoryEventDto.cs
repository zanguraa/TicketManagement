namespace Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class CategoryEventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public Guid Categoryid { get; set; }
    }
}
