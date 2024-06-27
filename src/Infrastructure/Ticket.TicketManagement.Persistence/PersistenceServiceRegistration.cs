using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Persistence.Repositories;

namespace Ticket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TicketManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaserRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;

        }
    }
}
