using Ecommerce.VO.Entities;
using Ecommerce.VO.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Ecommerce.DataAccess
{
    public class ProductDL : DbManager
    {
        public ProductDL(string connectionString) : base(connectionString) { }
        public Product GetByUId(string UId)
        {
            string query = "Select * from tbl_Products where UId = @uId And Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = UId
            };
            DataTable dtProduct = ReadData(query, CommandType.Text, paramCollection);
            if (dtProduct != null && dtProduct.Rows.Count > 0)
            {
                return new Product
                {
                    Name = dtProduct.Rows[0]["Name"].ToString(),
                    UId = dtProduct.Rows[0]["UId"].ToString(),
                    Price = ConversionUtility.ConvertToDecimal(dtProduct.Rows[0]["Price"]),
                    CategoryUId = dtProduct.Rows[0]["CategoryUId"].ToString()
                };
            }
            return null;
        }
        public List<Product> SearchByName(string searchParam)
        {
            string query = "Select * from tbl_Products where Name like '%@name%' And Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@name"] = searchParam
            };
            DataTable dtProduct = ReadData(query, CommandType.Text, paramCollection);
            if (dtProduct != null && dtProduct.Rows.Count > 0)
            {
                List<Product> products = (from DataRow dr in dtProduct.Rows
                                          select new Product()
                                          {
                                              Name = dr["Name"].ToString(),
                                              UId = dr["UId"].ToString(),
                                              Price = ConversionUtility.ConvertToDecimal(dr["Price"]),
                                              CategoryUId = dr["CategoryUId"].ToString()
                                          }).ToList();
                return products;
            }
            return null;
        }
        public void AddProduct(Product product)
        {
            string query = "Insert into tbl_Products(UId,Name,Price,CategoryUId) Values (@uId, @name, @price, @categoryId)";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = product.UId,
                ["@name"] = product.Name,
                ["@price"] = product.Price == null ? DBNull.Value : (object)product.Price,
                ["@categoryId"] = product.CategoryUId
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public void UpdateProduct(Product product)
        {
            string query = "Update tbl_Products Set Name = @name, Price = @price, CategoryUId = @categoryId Where UId = @uId";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = product.UId,
                ["@name"] = product.Name,
                ["@price"] = product.Price == null ? DBNull.Value : (object)product.Price,
                ["@categoryId"] = product.CategoryUId
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public void DeleteProduct(string uId)
        {
            string query = "Update tbl_Products Set Delete_Flag = 1 Where UId = @uId";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = uId,
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public int GetCategory(string categoryUId)
        {
            string query = "Select Count(UId) from tbl_Categories where UId = @UId and Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@UId"] = categoryUId,
            };
            object result = ReadSigularData(query, CommandType.Text, paramCollection);
            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);
            return 0;
        }
        public int GetInvoicesByProduct(string productUId)
        {
            string query = "Select Count(Id) from tbl_ProductsInvoices where ProductUId = @UId and Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@UId"] = productUId,
            };
            object result = ReadSigularData(query, CommandType.Text, paramCollection);
            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);
            return 0;
        }
    }
}
