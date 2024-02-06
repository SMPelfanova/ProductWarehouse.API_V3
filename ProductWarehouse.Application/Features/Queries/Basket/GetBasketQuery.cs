using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Basket;
public record GetBasketQuery(Guid UserId) : IRequest<BasketDto>;