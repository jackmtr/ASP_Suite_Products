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
        public string Description { get; set; }
        public int? Package_Id { get; set; }
    }
}