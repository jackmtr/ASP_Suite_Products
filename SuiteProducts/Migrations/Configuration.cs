namespace SuiteProducts.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuiteProducts.Models.SuitesProductDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SuiteProducts.Models.SuitesProductDb";
        }

        protected override void Seed(SuiteProducts.Models.SuitesProductDb context)
        {

            //context.Packages.AddOrUpdate(r => r.Package_Name,
            //    new Package
            //    {
            //        Package_Name = "All-Star Package",
            //        Price = 415.0F,
            //        Products = new List<Product> {
            //            new Product
            //            {
            //                Product_Name = "Popcorn",
            //                Price = 18.0F,
            //                Catagory = "snack",
            //                Description = "Bottomless",
            //            },

            //            new Product
            //            {
            //                Product_Name = "Fresh Vegetable",
            //                Price = 60.00F,
            //                Catagory = "snack",
            //                Description = "Baby carrots, celery, grape tomatoes, cauliflower, broccoli, cucumber, radish, peppers, sour cream dill dip",
            //            },
            //            new Product
            //            {
            //                Product_Name = "Fresh Fruit",
            //                Price = 65.0F,
            //                Catagory = "snack",
            //                Description = "Watermelon, cantaloupe, pineapple, honeydew, strawberries, raspberries, blueberries",
            //            },
            //            new Product
            //            {
            //                Product_Name = "Kettle Chips",
            //                Price = 24.0F,
            //                Catagory = "snack",
            //                Description = "French Onion Dip",
            //            }
            //        }
            //    },
            //    new Package {
            //        Package_Name = "Ultimate Sports Package",
            //        Price = 670.0F,
            //        Products = new List<Product> {
            //            new Product
            //            {
            //                Product_Name = "Premium Cheese Platter",
            //                Price = 100.00F,
            //                Catagory = "snack",
            //                Description = "Artisan selection of assorted, perfecly ripened local and international cheeses, pear jam, grpes, dried fruits.",
            //            },
            //        }
            //    });

            //context.Products.AddOrUpdate(r => r.Product_Name,
            //    new Product {
            //        Product_Name = "Dry Roasted Peanuts",
            //        Price = 22.0F,
            //        Catagory = "snack",
            //    },
            //    new Product
            //    {
            //        Product_Name = "Crispy Chicken Tenders",
            //        Price = 75.0F,
            //        Catagory = "main",
            //        Description = "Honey mustard sauce",
            //    }
            //);

            var packages = new List<Package> {
                new Package { Package_Name = "All-Star Package", Price = 415F, Products = new List<Product>()},
                new Package { Package_Name = "All-Star Package+", Price = 685F, Products = new List<Product>()},
                new Package { Package_Name = "Ultimate Sports Package", Price = 670F, Products = new List<Product>()},
                new Package { Package_Name = "Ultimate Sports Package+", Price = 995F, Products = new List<Product>()},
                new Package { Package_Name = "Top Shelf Package", Price = 995, Products = new List<Product>()},
                new Package { Package_Name = "Top Shelf Package+", Price = 1365, Products = new List<Product>()},
                new Package { Package_Name = "Snack Package", Price = 55F, Products = new List<Product>()},
            };

            packages.ForEach(s => context.Packages.AddOrUpdate(p => p.Package_Id, s));
            context.SaveChanges();


            //int[] array = new int[5];
            //string[] array2 = new string["fsdf", "Sdfsdf"];
            var products = new List<Product>
            {
                

                new Product { Product_Name = "Popcorn", Price = 18F, Catagory = "snack", Event_Day = true, Symbols = new[] {"GF"}, Description = "Bottomless"},
                new Product { Product_Name = "Kettle Chips", Price = 24F, Catagory = "snack", Event_Day = true, Symbols = new[] {""}, Description = ""},
                new Product { Product_Name = "Fresh Vegetable Platter", Price = 60F, Catagory = "cold_platters", Event_Day = true, Symbols = new[] {"GF", "V"}, Description = ""},
                new Product { Product_Name = "Classic Ceaser", Price = 32F, Catagory = "salads", Event_Day = true, Symbols = new[] {""}, Description = ""},
                new Product { Product_Name = "Crispy Chicken Tender", Price = 75F, Catagory = "appetizers", Event_Day = true, Symbols = new[] {""}, Description = ""},
                new Product { Product_Name = "Glazed Baby Back Ribs", Price = 90F, Catagory = "appetizers", Event_Day = true, Symbols = new[] {"GF"}, Description = ""},
                new Product { Product_Name = "Crunchy Tiger Prawns", Price = 85F, Catagory = "appetizers", Event_Day = true, Symbols = new[] {""}, Description = ""},
                new Product { Product_Name = "Fresh Fruit Platter", Price = 65F, Catagory = "cold_platters", Event_Day = true, Symbols = new[] {"GF", "V"}, Description = ""},
                new Product { Product_Name = "Fudge Nut Brownies", Price = 45F, Catagory = "desserts", Event_Day = true, Symbols = new[] {""}, Description = ""},
                //new Product { Product_Name = "", Price = , Catagory = , Event_Day = , Symbols = [""], Description = ""},
                //new Product { Product_Name = "", Price = , Catagory = , Event_Day = , Symbols = [""], Description = ""},
            };

            products.ForEach(s => context.Products.AddOrUpdate( p => p.Product_Id, s));
            context.SaveChanges();

            AddOrUpdatePackages(context, "Popcorn", "All-Star Package");

        }

        void AddOrUpdatePackages(SuiteProducts.Models.SuitesProductDb context, string product_name, string package_name) {
            var pkg = context.Packages.SingleOrDefault(pa => pa.Package_Name == package_name);
            var pdt = pkg.Products.SingleOrDefault(pr => pr.Product_Name == product_name);

            if (pdt == null) {
                pkg.Products.Add(context.Products.Single(i => i.Product_Name == product_name));
            }
        }
    }
}
