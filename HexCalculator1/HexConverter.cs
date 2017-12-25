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
         int value = 0;

         int.TryParse (input, out value);

         return value.ToString ("X");
      }
   }
}