using System;
using System.Diagnostics.CodeAnalysis;

namespace Mbiza.Pokedex
{
    [ExcludeFromCodeCoverage]
    public static class CommonHelper
    {
        /// <summary>
        /// Converts string to int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            int.TryParse(value, out int result);
            return result;
        }
    }
}
