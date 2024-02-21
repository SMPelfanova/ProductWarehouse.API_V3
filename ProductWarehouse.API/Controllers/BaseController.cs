using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public abstract class BaseController : ControllerBase
{
}