using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HexCalculator1
{
   public static class HexConverter
   {
      public static string ConvertDecToHex (string input)
      {
         UInt64 value = 0;

         UInt64.TryParse (input, out value);

         return value.ToString ("X");
      }

      public static string ConvertHexToDec (string input)
      {
         Int64 value = Convert.ToInt64 (input, 16);

         return value.ToString ();
      }
   }
}