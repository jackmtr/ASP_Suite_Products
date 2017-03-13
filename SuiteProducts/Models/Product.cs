using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuiteProducts.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public float Price { get; set; }
        public string Catagory { get; set; }
        public bool Event_Day { get; set; }
        public string[] Symbols { get; set; }
        public string Description { get; set; }
        public int? Package_Id { get; set; } //remove this column when adding new seed data

        public virtual ICollection<Package> Packages { get; set; }
    }
}