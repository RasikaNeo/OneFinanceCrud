using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;

namespace OneFinanceCrud.Repository
{
    public interface IProductRepository
    {
        public Task<List<GetAllProductDto>> GetAllProductsAsync();

        public Task<GetAllProductDto> GetProductByIdAsync(int id);
        public Task<AddProductDto> AddProductAsync(Product product);
        public Task<bool> DeleteProductAsync(int id);


        public Task<UpdateProductDto> UpdateProductAsync(Product product);
        
    }
}
