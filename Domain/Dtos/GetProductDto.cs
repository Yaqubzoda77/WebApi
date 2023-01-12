﻿namespace Domain.Dtos;

public class GetProductDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductCount { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
    public string Company { get; set; }

    public GetProductDto()
    {
        
    }
}