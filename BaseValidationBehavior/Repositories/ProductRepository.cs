using BaseValidationBehavior.Context;
using BaseValidationBehavior.Entities;

namespace BaseValidationBehavior.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> AddAsync(Product product)
    {
        using (BaseDbContext context = new())
        {
            await context.Products.AddAsync(product);
            context.SaveChanges();
            return product;
        }
    }
}
