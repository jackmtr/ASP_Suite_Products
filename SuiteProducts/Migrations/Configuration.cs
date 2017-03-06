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
            //context.Products.AddOrUpdate(r => r.Product_Name,
            //    new Product
            //    {
            //        Product_Name = "Popcorn",
            //        Price = 18.0F,
            //        Catagory = "Snack",
            //        Description = "Bottomless",
            //    },

            //    new Product
            //    {
            //        Product_Name = "Fresh Vegetable",
            //        Price = 60.00F,
            //        Catagory = "Snack",
            //        Description = "Baby carrots, celery, grape tomatoes, cauliflower, broccoli, cucumber, radish, peppers, sour cream dill dip",
            //    },

            //    new Product
            //    {
            //        Product_Name = "Premium Cheese Platter",
            //        Price = 100.00F,
            //        Catagory = "Snack",
            //        Description = "Artisan selection of assorted, perfecly ripened local and international cheeses, pear jam, grpes, dried fruits.",
            //    },

            //    new Product
            //    {
            //        Product_Name = "Fresh Fruit",
            //        Price = 65,
            //        Catagory = "Snack",
            //        Description = "Watermelon, cantaloupe, pineapple, honeydew, strawberries, raspberries, blueberries",
            //    });

            context.Packages.AddOrUpdate(r => r.Package_Name,
                new Package
                {
                    Package_Name = "All-Star Package",
                    Price = 415.0F,
                    Products = new List<Product> {
                        new Product
                        {
                            Product_Name = "Popcorn",
                            Price = 18.0F,
                            Catagory = "snack",
                            Description = "Bottomless",
                        },

                        new Product
                        {
                            Product_Name = "Fresh Vegetable",
                            Price = 60.00F,
                            Catagory = "snack",
                            Description = "Baby carrots, celery, grape tomatoes, cauliflower, broccoli, cucumber, radish, peppers, sour cream dill dip",
                        },
                        new Product
                        {
                            Product_Name = "Fresh Fruit",
                            Price = 65.0F,
                            Catagory = "snack",
                            Description = "Watermelon, cantaloupe, pineapple, honeydew, strawberries, raspberries, blueberries",
                        },
                        new Product
                        {
                            Product_Name = "Kettle Chips",
                            Price = 24.0F,
                            Catagory = "snack",
                            Description = "French Onion Dip",
                        }
                    }
                },
                new Package {
                    Package_Name = "Ultimate Sports Package",
                    Price = 670.0F,
                    Products = new List<Product> {
                        new Product
                        {
                            Product_Name = "Premium Cheese Platter",
                            Price = 100.00F,
                            Catagory = "snack",
                            Description = "Artisan selection of assorted, perfecly ripened local and international cheeses, pear jam, grpes, dried fruits.",
                        },
                    }
                });

            context.Products.AddOrUpdate(r => r.Product_Name,
                new Product {
                    Product_Name = "Dry Roasted Peanuts",
                    Price = 22.0F,
                    Catagory = "snack",
                },
                new Product
                {
                    Product_Name = "Crispy Chicken Tenders",
                    Price = 75.0F,
                    Catagory = "main",
                    Description = "Honey mustard sauce",
                }
            );
        }
    }
}
