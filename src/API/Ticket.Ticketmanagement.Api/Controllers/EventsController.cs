using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Ticket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using Ticket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace Ticket.Ticketmanagement.Api.Controllers
{
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventListVm>> GetEventById(Guid id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }

    }
}