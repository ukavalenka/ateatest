using System;
using System.Collections.Generic;
using System.Text;

namespace ATEATECHNICAL.Utils.Extensions
{
    public static class AgrumentsHelperExtension
    {
        public static string AddArgument(this string arg1, string arg2)
        {
            if (double.TryParse(arg1, out double arg1num) && double.TryParse(arg2, out double arg2num))
            {
                return (arg1num + arg2num).ToString();
            }

            return arg1 + arg2;
        }
    }
}
