using AutoMapper;
using OnlineShop.API.DTOs.Products;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.API.MapperConfigurations;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, AddProductResponse>();
        CreateMap<Product, DeleteProductResponse>();
        CreateMap<Product, GetProductByIdResponse>();
        CreateMap<Product, GetProductsListResponse>();
        CreateMap<Product, UpdateProductResponse>();
    }
}