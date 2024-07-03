using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ticket.TicketManagement.Application.Contracts.Infrastructure;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Application.Models.Mail;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService, ILogger<CreateEventCommandHandler> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;

        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email() { To = "zanguraa@gmail.com", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            }

            return @event.EventId;
        }
    }
}
