using System.ComponentModel.DataAnnotations;

namespace OneFinanceCrud.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public List<Product>? products { get; set; }
    }
}
