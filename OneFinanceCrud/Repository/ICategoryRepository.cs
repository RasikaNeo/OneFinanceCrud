using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;
using System.Threading.Tasks;

namespace OneFinanceCrud.Repository
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<AddCategoryDto> AddCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(Category category);

        public Task<Category> UpdateCategoryAsync(Category category);

    }
}
