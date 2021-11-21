using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.VO.Utilities
{
    public static class ConversionUtility
    {
        public static decimal? ConvertToDecimal(object value)
        {
            if (value != DBNull.Value)
                return Convert.ToDecimal(value);
            return null;
        }
    }
}
