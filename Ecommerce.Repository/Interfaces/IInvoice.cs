using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IInvoice
    {
        void AddOrUpdateInvoices(Invoice invoice);
        Invoice GetByUId(string uId);
        IEnumerable<Invoice> SearchByProductName(string word);
    }
}
