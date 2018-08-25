using BlazorShop.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlazorShop.Server.Data
{
    public class BlazorShopDbContext : DbContext
    {
        protected BlazorShopDbContext()
        {
        }
        public BlazorShopDbContext(DbContextOptions<BlazorShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataSeeding.Seed(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        public virtual DbSet<Product> Products { get; set; }

    }
}
