using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Basket.GetBasket;
public record GetBasketQuery(Guid UserId) : IRequest<BasketDto>;