using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.VO.Entities;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICategory: IOperations<Category>
    {
        (bool isSuccess, string message) DeleteCategory(string uId);
    }
}
