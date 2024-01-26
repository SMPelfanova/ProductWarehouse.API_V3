﻿using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Orders.AddOrder;
public class CreateOrderCommand : IRequest
{
    public OrderStatusDto Status { get; set; }
    public Guid StatusId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetailsDto> OrderDetails { get; set; }
}
