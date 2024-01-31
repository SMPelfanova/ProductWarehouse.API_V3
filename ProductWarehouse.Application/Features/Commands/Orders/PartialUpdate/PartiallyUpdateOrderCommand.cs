using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class PartialUpdateOrderCommand() : IRequest
{
    public Guid Id { get; set; }
    public required JsonPatchDocument<PartialUpdateOrderRequest> PatchDocument { get; set; }
}
