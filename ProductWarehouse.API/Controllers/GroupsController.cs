using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;
using ProductWarehouse.Application.Features.Queries.Groups.GetGroup;

namespace ProductWarehouse.API.Controllers;
public class GroupsController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetGroups([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllGroupsQuery());
        if (result == null || !result.Any())
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGroup([FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetGroupQuery(id));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

}
