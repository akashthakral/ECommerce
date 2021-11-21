using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.VO.Entities
{
    public class Invoice
    {
        public string UId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public IEnumerable<ProductDetails> Products { get; set; }
    }
}
