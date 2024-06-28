using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace Ticket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExporterEventsToCsv(List<EventExporterDto> eventExporterDtos);
    }
}
