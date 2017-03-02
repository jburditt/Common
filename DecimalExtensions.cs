using System;

namespace Common
{
    public static class DecimalExtensions
    {
        public static decimal _Round(this decimal n, int decimals = 2)
        {
            return decimal.Round(n, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
