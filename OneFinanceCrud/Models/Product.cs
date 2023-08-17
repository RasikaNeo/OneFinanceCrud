using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneFinanceCrud.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int cat_Id { get; set; }


        public Category? Category { get; set; }
    }
}
