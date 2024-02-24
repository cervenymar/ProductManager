using Microsoft.EntityFrameworkCore;

namespace ProductManager
{
    
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "YourConnectionString" with your actual PostgreSQL connection string
                string connectionString = "Host=localhost;Database=product_manager;Username=postgres;Password=password";

                optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    // Configure additional Npgsql-specific options if needed
                    npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                });
            }
            
        }
    }

}
