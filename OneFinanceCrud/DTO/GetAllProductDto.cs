﻿namespace OneFinanceCrud.DTO
{
    public class GetAllProductDto
    {

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int cat_Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

    }
}
