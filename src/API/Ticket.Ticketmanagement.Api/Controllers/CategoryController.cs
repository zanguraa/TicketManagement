﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

namespace Ticket.Ticketmanagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAcllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }


    }
}
