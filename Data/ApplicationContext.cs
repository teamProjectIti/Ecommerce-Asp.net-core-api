using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Model.Dashbord;
using WebApplication1.Model.Dashbord.Cart;
using WebApplication1.Model.Dashbord.Order;
using WebApplication1.Model.Order;

namespace WebApplication1.Data
{
    public class ApplicationContext :IdentityDbContext<ApplicationUser>
    {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<categore> categores { get; set; }
    public DbSet<product> products { get; set; }
    public DbSet<Model.Dashbord.ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductClothe> ProductClothes { get; set; }
    public DbSet<ProductGallary> ProductGallarys { get; set; }
    public DbSet<CustomerBasket> CustomerBaskets { get; set; }
    public DbSet<OredrProduct> OredrProducts { get; set; }
    public DbSet<OrderUser> OrderUsers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
        

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
}


