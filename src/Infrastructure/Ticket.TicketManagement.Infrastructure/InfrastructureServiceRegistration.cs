using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticket.TicketManagement.Application.Contracts.Infrastructure;
using Ticket.TicketManagement.Application.Models.Mail;
using Ticket.TicketManagement.Infrastructure.Mail;

namespace Ticket.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
