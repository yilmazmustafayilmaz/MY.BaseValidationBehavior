using AutoMapper;
using BaseValidationBehavior.Entities;
using BaseValidationBehavior.Features.Commands;
using BaseValidationBehavior.Features.Dto;

namespace BaseValidationBehavior.Features.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductDto>().ReverseMap();
    }
}
