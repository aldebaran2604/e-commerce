using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    #region Properties

    public DbSet<Product> Products {get; set;} = null!;

    public DbSet<ProductBrand> ProductBrans { get; set; } = null!;

    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    #endregion

    #region Constructors
    public StoreContext(DbContextOptions<StoreContext> options): base(options)
    {

    }

    #endregion

    #region Methods Override

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion
}