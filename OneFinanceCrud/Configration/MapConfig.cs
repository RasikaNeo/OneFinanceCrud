using AutoMapper;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Model;

namespace OneFinanceCrud.Configration
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Product , AddProductDto>().ReverseMap();
            CreateMap<Product, GetAllProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Category, UpdateProductDto>().ReverseMap();

            

        }
    }
}
