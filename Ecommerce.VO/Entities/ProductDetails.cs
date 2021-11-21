using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.VO.Entities
{
    public class ProductDetails: Product
    {
        public string CategoryName { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
