using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.VO.Entities
{
    public class Product
    {
        public string UId { get; set; }
        public string CategoryUId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
