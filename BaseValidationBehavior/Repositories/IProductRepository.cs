using BaseValidationBehavior.Entities;

namespace BaseValidationBehavior.Repositories;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
}
