using Identity;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Ticket.Ticketmanagement.Api.Middleware;
using Ticket.Ticketmanagement.Api.Services;
using Ticket.TicketManagement.Application;
using Ticket.TicketManagement.Application.Contracts;
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
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();

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

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();  

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapIdentityApi<ApplicationUser>();

            app.MapPost("/Logout", async (ClaimsPrincipal user,
                SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.Ok();
            });

            app.UseCors("open");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }



            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCustomExceptionsHandler();

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;

        }
    }
}
