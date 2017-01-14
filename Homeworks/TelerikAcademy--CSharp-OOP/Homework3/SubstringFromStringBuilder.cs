using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public static class SubstringFromStringBuilder
    {
        public static StringBuilder Substring(this StringBuilder original, int startIndex)
        {
            StringBuilder result = new StringBuilder();
            result.Append(
                original.ToString().Substring(startIndex)
                );
            return result;
        }
        public static StringBuilder Substring(this StringBuilder original, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder();
            result.Append(
                original.ToString().Substring(startIndex, length)
                );
            return result;
            
        }
    }
}
