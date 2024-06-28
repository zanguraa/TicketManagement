using CsvHelper;
using System.Globalization;
using Ticket.TicketManagement.Application.Contracts.Infrastructure;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace Ticket.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExporterEventsToCsv(List<EventExporterDto> eventExporterDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExporterDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
