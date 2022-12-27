using System;
using System.Collections.Generic;
using System.Linq;

namespace ATEATECHNICAL.Utils.Extensions
{
    public static class AgrumentsHelperExtension
    {
        private static List<TestDelegate> testDelegates = new List<TestDelegate>()
        {
            TryAddArgsAsInteger,
            TryAddArgsAsFloat,
            TryAddArgsAsDecimal,
            //TryAddArgsAsDouble,
        };

        delegate bool TestDelegate(string arg1, string arg2, out string sum);
        public static string AddArgument(this string arg1, string arg2)
        {
            foreach (TestDelegate testDelegate in testDelegates)
            {
                if(testDelegate(arg1, arg2, out string result))
                {
                    return result;
                }
            }

            return arg1 + arg2;
        }

        private static bool TryAddArgsAsInteger(string arg1, string arg2, out string res)
        {
            res = string.Empty;
            if(int.TryParse(arg1, out int n1) && int.TryParse(arg2, out int n2))
            {
                res = (n1 + n2).ToString();
                return true;
            }
            return false;
        }

        private static bool TryAddArgsAsFloat(string arg1, string arg2, out string res)
        {
            res = string.Empty;

            RemoveEndingCharacterForArguments(ref arg1, ref arg2, 'f');

            if (float.TryParse(arg1, out float n1) && float.TryParse(arg2, out float n2))
            {
                if (float.IsInfinity(n1) || float.IsInfinity(n2))
                {
                    return false;              
                }

                res = (n1 + n2).ToString();
                return true;
            }

            return false;
        }

        private static bool TryAddArgsAsDecimal(string arg1, string arg2, out string res)
        {
            res = string.Empty;

            RemoveEndingCharacterForArguments(ref arg1, ref arg2, 'm', 'f');

            if (decimal.TryParse(arg1, out decimal n1) && decimal.TryParse(arg2, out decimal n2))
            {
                decimal sum = decimal.Add(n1, n2);
                res = sum.ToString();
                return true;
            }

            return false;
        }




        //private static bool TryAddArgsAsDouble(string arg1, string arg2, out string res)
        //{
        //    res = string.Empty;
            
        //    RemoveEndingCharacterForArguments(ref arg1, ref arg2, 'm', 'f', 'd');

        //    if (double.TryParse(arg1, out double n1) && double.TryParse(arg2, out double n2))
        //    {
        //        res = (n1 + n2).ToString();
        //        return true;
        //    }

        //    return false;
        //}

        

        private static void RemoveEndingCharacterForArguments(ref string arg1, ref string arg2, params char[] characters)
        {
            if(characters.Contains(arg1[arg1.Length - 1]))
            {
                arg1 = arg1.Substring(0, arg1.Length - 1);
            }
            if (characters.Contains(arg2[arg2.Length - 1]))
            {
                arg2 = arg2.Substring(0, arg2.Length - 1);
            }
        }
    }
}
