namespace EShop.Service.DiscountGRPC.DataAccess.Context
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Discount", DiscountAmount = 150 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", DiscountAmount = 100 }
                );
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
