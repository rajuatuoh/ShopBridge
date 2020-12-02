using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridgeAPIApps.Models
{
    public class ProductModel
    {
        public int productId { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public float productPrice { get; set; }

        public string productImg { get; set; }

       
    }
}