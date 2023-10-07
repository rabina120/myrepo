using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Utility
{
   public static class StringToNumber
    {
       
           public static string toFixed(this float number, uint decimals)
           {
               return number.ToString("N" + decimals);
           }
       
    }
}
