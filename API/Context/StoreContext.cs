using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;
internal class StoreContext : DbContext
{
    #region Properties

    public DbSet<Product>? products {get; set;}

    #endregion

    #region Constructors
    public StoreContext(DbContextOptions<StoreContext> options): base(options)
    {

    }

    #endregion
}