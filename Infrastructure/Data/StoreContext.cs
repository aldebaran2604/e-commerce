using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    #region Properties

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductBrand> ProductBrans { get; set; } = null!;

    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    #endregion Properties

    #region Constructors

    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    #endregion Constructors

    #region Methods Override

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                }
            }
        }
    }

    #endregion Methods Override
}