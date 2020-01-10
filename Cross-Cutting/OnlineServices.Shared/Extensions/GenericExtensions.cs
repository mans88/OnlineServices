using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.Extensions
{
    public static class GenericExtensions
    {
        private static bool Equals<TIdType>(this TIdType a, TIdType b)
        {
            return EqualityComparer<TIdType>.Default.Equals(a, b);
        }
    }
}
