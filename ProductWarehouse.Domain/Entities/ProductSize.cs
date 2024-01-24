﻿namespace ProductWarehouse.Domain.Entities;
public class ProductSize
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public Size Size { get; set; }
    public Guid SizeId { get; set; }
    public int QuantityInStock { get; set; }
}
