using Ecommerce.DataAccess;
using Ecommerce.Repository.Interfaces;
using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class CategoryBL : ICategory
    {
        private CategoryDL _categoryDl;
        public CategoryBL(CategoryDL categoryDL)
        {
            _categoryDl = categoryDL;
        }
        public (bool isSuccess, string message) Add(Category objectToAdd)
        {
            List<Category> categories = _categoryDl.SearchByName(objectToAdd.Name);
            if(categories == null)
            {
                _categoryDl.AddCategory(objectToAdd);
                return (true, "Category added successfully!");
            }
            return (false, "Category already exists");
        }

        public (bool isSuccess, string message) DeleteCategory(string uId)
        {
            int productCount = _categoryDl.GetProductCountByCategory(uId);
            if (productCount == 0)
            {
                _categoryDl.DeleteCategory(uId);
                return (true,"Category deleted successfully!");
            }
            return (false, "Products exist for this category");
        }

        public Category GetByUId(string uId) => _categoryDl.GetByUId(uId);

        public IEnumerable<Category> SearchByName(string word) => _categoryDl.SearchByName(word);

        public (bool isSuccess, string message) Update(Category objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
