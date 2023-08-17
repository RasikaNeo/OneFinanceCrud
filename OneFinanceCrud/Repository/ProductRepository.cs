using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneFinanceCrud.Context;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;

namespace OneFinanceCrud.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly IMapper _mapper;
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
             _mapper = mapper;
        }
        public async Task<AddProductDto> AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            var Pro = _mapper.Map<AddProductDto>(product);
            return Pro;

        }



        public async Task<bool> DeleteProductAsync(int id) // Change the parameter type
        {
           

            var existingProduct = await _dbContext.Products.FindAsync(id);

            if (existingProduct == null)
                return false;

            var exstingCategory = await _dbContext.Categories.FindAsync(existingProduct.cat_Id);
            _dbContext.Products.Remove(existingProduct);
            _dbContext.Categories.Remove(exstingCategory);
            await _dbContext.SaveChangesAsync();

            return true;


        }

       

        public async Task<List<GetAllProductDto>> GetAllProductsAsync()
        {
           
            var products = await _dbContext.Products
            .Include(p => p.Category) // Include the related Category entity
            .ToListAsync();

            var productDtos = _mapper.Map<List<GetAllProductDto>>(products);

            for (int i = 0; i < productDtos.Count; i++)
            {
                productDtos[i].CategoryName = products[i].Category.CategoryName;
                productDtos[i].Description = products[i].Category.Description;
            }

            return productDtos;
        }

        public async Task<GetAllProductDto> GetProductByIdAsync(int id)
        {
            
            var product = await _dbContext.Products
           .Include(p => p.Category) 
           .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            var productDto = _mapper.Map<GetAllProductDto>(product);
            productDto.CategoryName = product.Category.CategoryName;
            productDto.Description = product.Category.Description;

            return productDto;
        }

        public async Task<UpdateProductDto> UpdateProductAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FindAsync(product.Id);

            if (existingProduct == null)
                return null;

            _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);

            await _dbContext.SaveChangesAsync();
            var pro = _mapper.Map<UpdateProductDto>(existingProduct);
            return pro;
        }


    }
}
