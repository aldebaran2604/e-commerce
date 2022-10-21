using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    #region Properties

    public DbSet<Product> Products {get; set;} = null!;

    #endregion

    #region Constructors
    public StoreContext(DbContextOptions<StoreContext> options): base(options)
    {

    }

    #endregion
}