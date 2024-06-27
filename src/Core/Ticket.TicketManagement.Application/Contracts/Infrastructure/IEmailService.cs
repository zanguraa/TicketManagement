using Ticket.TicketManagement.Application.Models.Mail;

namespace Ticket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
