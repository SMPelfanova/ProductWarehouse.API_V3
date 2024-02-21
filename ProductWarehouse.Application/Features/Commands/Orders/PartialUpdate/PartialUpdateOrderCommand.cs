using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;

public class PartialUpdateOrderCommand() : IRequest
{
	public Guid Id { get; set; }
	public JsonPatchDocument<PartialUpdateOrderCommandRequest> PatchDocument { get; set; }
}