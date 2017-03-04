using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuiteProducts.Models
{
    public class ProductPackageVM
    {
        public int Package_Id { get; set; }
        public string Package_Name { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
    }
}