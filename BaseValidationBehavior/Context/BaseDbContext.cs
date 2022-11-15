using BaseValidationBehavior.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseValidationBehavior.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext()
    {
    }
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.; database=ValidationBehaviorDb; integrated security=true;");
    }
}
