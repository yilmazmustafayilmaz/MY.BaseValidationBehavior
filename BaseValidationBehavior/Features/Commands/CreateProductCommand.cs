using AutoMapper;
using BaseValidationBehavior.Entities;
using BaseValidationBehavior.Features.Dto;
using BaseValidationBehavior.Repositories;
using MediatR;

namespace BaseValidationBehavior.Features.Commands;

public class CreateProductCommand : IRequest<CreatedProductDto>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<Product>(request);
            var createdProduct = await _productRepository.AddAsync(mappedProduct);
            var mappedProductDto = _mapper.Map<CreatedProductDto>(createdProduct);
            return mappedProductDto;
        }
    }
}
