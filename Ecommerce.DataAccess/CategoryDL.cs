using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Ecommerce.DataAccess
{
    public class CategoryDL : DbManager
    {
        public CategoryDL(string connectionString) : base(connectionString) { }
        public Category GetByUId(string UId)
        {
            string query = "Select * from tbl_Categories where UId = @uId And Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = UId
            };
            DataTable dtCategory = ReadData(query, CommandType.Text, paramCollection);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                return new Category
                {
                    Name = dtCategory.Rows[0]["Name"].ToString(),
                    Uid = dtCategory.Rows[0]["UId"].ToString(),
                };
            }
            return null;
        }
        public List<Category> SearchByName(string searchParam)
        {
            string query = "Select * from tbl_Categories where Name like '%@name%' And Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@name"] = searchParam
            };
            DataTable dtCategory = ReadData(query, CommandType.Text, paramCollection);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                List<Category>  categories = (from DataRow dr in dtCategory.Rows
                 select new Category()
                 {
                     Name = dr["Name"].ToString(),
                     Uid = dr["UId"].ToString(),
                 }).ToList();
                return categories;
            }
            return null;
        }
        public void AddCategory(Category category)
        {
            string query = "Insert into tbl_Categories(UId,Name) Values (@uId, @name)";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = category.Uid,
                ["@name"] = category.Name
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public void UpdateCategory(Category category)
        {
            string query = "Update tbl_Categories Set Name = @name Where UId = @uId";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = category.Uid,
                ["@name"] = category.Name
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public void DeleteCategory(string uId)
        {
            string query = "Update tbl_Categories Set Delete_Flag = 1 Where UId = @uId";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@uId"] = uId,
            };
            ExecuteQuery(query, CommandType.Text, paramCollection);
        }
        public int GetProductCountByCategory(string categoryUId)
        {
            string query = "Select Count(UId) from tbl_Products where CategoryUId = @catUId and Delete_Flag = 0";
            Dictionary<string, object> paramCollection = new Dictionary<string, object>
            {
                ["@catUId"] = categoryUId,
            };
            object result = ReadSigularData(query, CommandType.Text, paramCollection);
            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);
            return 0;
        }
    }
}
