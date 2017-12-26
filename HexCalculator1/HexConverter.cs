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

         string hexString = value.ToString ("X");

         // Now add spaces every 4th character

         string newHex = PadHexString (hexString);
 
         return newHex;
      }

      public static string ConvertHexToDec (string input)
      {
         // Remove any spaces first
         string hexString = "";
         foreach(char c in input)
         {
            if (c != ' ')
            {
               hexString += c;
            }
         }

         Int64 value = Convert.ToInt64 (hexString, 16);

         return value.ToString ();
      }

      public static string PadHexString (string input)
      {
         string hexString = "";

         while (input [0] == '0')
         {
            input = input.Remove (0, 1);
         }

         foreach(char c in input)
         {
            if (c != ' ')
            {
               hexString += c;
            }
         }

         // Now reinsert the spaces;

         string newHex = "";
         int length = hexString.Length;
         int charPointer = hexString.Length - 1;
         int breakCounter = 0;

         while (charPointer >= 0)
         {
            newHex = hexString [charPointer] + newHex;
            charPointer--;
            breakCounter++;

            if (breakCounter >= 4)
            {
               newHex = " " + newHex;
               breakCounter = 0;
            }
         }

         if (hexString.Length % 4 > 0)
         {
            int numPadding = 4 - hexString.Length % 4;

            while (numPadding > 0)
            {
               newHex = "0" + newHex;
               numPadding--;
            }
         }

         return newHex;
      }
   }
}