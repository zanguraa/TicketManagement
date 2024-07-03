using Ticket.Ticketmanagement.Api;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Ticket Api Starting");


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(),
    true
    );

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();


app.Run();
public partial class Program { }
