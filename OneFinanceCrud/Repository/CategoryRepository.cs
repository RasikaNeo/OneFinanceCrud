using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OneFinanceCrud.Context;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;
using System;

namespace OneFinanceCrud.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly IMapper _mapper;

        private readonly ProductDbContext _dbContext;

        public CategoryRepository(ProductDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AddCategoryDto>  AddCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            var cat=_mapper.Map<AddCategoryDto>(category);
            return cat;

        }

        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            var ExsitingCategories = await _dbContext.Categories.FindAsync(category.Id);
            if (ExsitingCategories == null)
                return false;
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

      

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }



        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(category.Id);

            if (existingCategory == null)
                return null;

            _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);

            await _dbContext.SaveChangesAsync();

            return existingCategory;
        }

       
    }
   }
