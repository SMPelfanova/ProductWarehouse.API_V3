﻿namespace ProductWarehouse.API.Models.Requests.Basket;

public class AddBasketLineRequest
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Guid SizeId { get; set; }
}