using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
}
