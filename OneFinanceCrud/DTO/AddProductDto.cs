using OneFinanceCrud.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFinanceCrud.DTO
{
    public class AddProductDto
    {

        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


        public string? CategoryName { get; set; }
        public string? Description { get; set; }


    }
}
