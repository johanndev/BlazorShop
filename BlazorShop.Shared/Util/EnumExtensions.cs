using System;
using System.Collections.Generic;

namespace BlazorShop.Shared.Util
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
