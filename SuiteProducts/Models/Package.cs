using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuiteProducts.Models
{
    public class Package
    {
        [Key]
        public int Package_Id { get; set; }
        public string Package_Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        //instead of hijacking the product index, maybe make a new view with the package and lazy loaded products
    }
}