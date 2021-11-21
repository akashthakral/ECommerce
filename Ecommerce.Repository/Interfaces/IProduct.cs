using Ecommerce.VO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProduct: IOperations<Product>
    {
        (bool isSuccess, string message) DeleteProduct(string uId,bool ignoreVoices);
    }
}
