using Ecommerce.Repository.Interfaces;
using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class InvoiceBL : IInvoice
    {
        public void AddOrUpdateInvoices(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Invoice GetByUId(string uId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> SearchByProductName(string word)
        {
            throw new NotImplementedException();
        }
    }
}
