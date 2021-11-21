using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IOperations<T>
    {
        T GetByUId(string uId);
        IEnumerable<T> SearchByName(string word);
        (bool isSuccess, string message) Add(T objectToAdd);
        (bool isSuccess, string message) Update(T objectToUpdate);
    }
}
