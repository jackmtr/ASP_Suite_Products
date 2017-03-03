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
    }
}