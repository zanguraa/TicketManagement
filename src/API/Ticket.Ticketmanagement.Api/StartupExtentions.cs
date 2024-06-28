using Ticket.TicketManagement.Application;
using Ticket.TicketManagement.Infrastructure;
using Ticket.TicketManagement.Persistence;

namespace Ticket.Ticketmanagement.Api
{
    public static class StartupExtentions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(
                options => options.AddPolicy
                ("open",
                policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ?? "https://loclahost:7020",
                builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"])
                .AllowAnyMethod()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyHeader()
                .AllowCredentials()));

            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;

        }
    }
}
