using Ecommerce.DataAccess;
using Ecommerce.Repository.Interfaces;
using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class ProductBL : IProduct
    {
        private ProductDL _productDl;
        public ProductBL(ProductDL productDl)
        {
            _productDl = productDl;
        }
        public (bool isSuccess, string message) Add(Product objectToAdd)
        {
            List<Product> products = _productDl.SearchByName(objectToAdd.Name);
            if (products != null)
                return (false, "Product already exists");
            if (_productDl.GetCategory(objectToAdd.CategoryUId) == 0)
                return (false, "Invalid Category");
            else
            {
                _productDl.AddProduct(objectToAdd);
                return (true, "Product added successfully");
            }
        }

        public (bool isSuccess, string message) DeleteProduct(string uId, bool ignoreVoices)
        {
            if (!ignoreVoices && _productDl.GetInvoicesByProduct(uId)>0)
                return (false, "Invoices exist for this Product");
            _productDl.DeleteProduct(uId);
            return (true, "Product deleted successfully!");
        }

        public Product GetByUId(string uId) => _productDl.GetByUId(uId);

        public IEnumerable<Product> SearchByName(string word) => _productDl.SearchByName(word);

        public (bool isSuccess, string message) Update(Product objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
