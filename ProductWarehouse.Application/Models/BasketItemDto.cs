﻿namespace ProductWarehouse.Application.Models;
public class BasketItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid SizeId { get; set; }
}
