using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuiteProducts.Models
{
    public class SuitesProductDb : DbContext
    {
        public SuitesProductDb() : base("name=DevelopmentConnection") { }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Package>()
                .HasMany(pa => pa.Products).WithMany(pr => pr.Packages)
                .Map(t => t.MapLeftKey("package_id")
                    .MapRightKey("product_id")
                    .ToTable("Package_Product"));
        }
    }
}