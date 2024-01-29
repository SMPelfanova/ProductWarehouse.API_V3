using MediatR;
using ProductWarehouse.Application.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class PartialUpdateOrderCommand() : IRequest
{
    public Guid Id { get; set; }
    public required JsonPatchDocument<OrderDto> PatchDocument { get; set; }
}
