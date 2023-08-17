using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;
using OneFinanceCrud.Repository;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OneFinanceCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository ,IMapper mapper , ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            

            try
            {
                var products = await _productRepository.GetAllProductsAsync();
                return Ok(products);
            }
            catch(Exception ex) {
                return StatusCode(500, "Error");
            }
           
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var Pro = _mapper.Map<Product>(product);
            var abc = new Category { CategoryName = product.CategoryName,Description = product.Description };
            var cat = await _categoryRepository.AddCategoryAsync(abc);
            Pro.cat_Id = cat.Id;
            var newproduct = await _productRepository.AddProductAsync(Pro);
            newproduct.CategoryName = cat.CategoryName;
            newproduct.Description = cat.Description;
            if (newproduct != null)
            {
                return Ok(newproduct);
            }
            else
            {
                return BadRequest();
            }

          
        }

        [HttpPut ("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(  [FromBody] UpdateProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pro = _mapper.Map<Product>(product);
         
            var updatedProduct = await _productRepository.UpdateProductAsync(pro);
            var abc = new Category { CategoryName = product.CategoryName , Id = product.cat_Id , Description = product.Description};
            var cat = await _categoryRepository.UpdateCategoryAsync(abc);
            
            updatedProduct.CategoryName = cat.CategoryName;
            updatedProduct.Description = cat.Description;
             
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id); 
            if (!result)
            {
                return StatusCode(500, "Failed to delete the product.");
            }

            return Ok();
        }
    }
}