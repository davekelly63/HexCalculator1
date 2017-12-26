using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HexCalculator1
{
   enum EntryMode
   {
      Decimal,
      Hex
   };

   [Activity (Label = "Hex Calculator", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
   public class MainActivity : Activity
   {
      TextView txtDec = null;
      TextView txtHex = null;

      Button btnDec = null;
      Button btnHex = null;

      EntryMode currentmode = EntryMode.Decimal;

      bool entering = false;

      Color defaultBackColor = Color.Black;

      Stack<Int64> calculationStack = new Stack<Int64> ();

      protected override void OnCreate (Bundle savedInstanceState)
      {
         base.OnCreate (savedInstanceState);

         // Set our view from the "main" layout resource
         SetContentView (Resource.Layout.Main);

         //EditText tvDec = FindViewById<EditText> (Resource.Id.editTextDec);
         //EditText tvHex = FindViewById<EditText> (Resource.Id.editTextHex);

         //tvDec.Text = "137";
         //tvHex.Text = HexConverter.ConvertDecToHex (tvDec.Text);

         Button btn0 = FindViewById<Button> (Resource.Id.button0);
         btn0.Click += HexButtonOnClick;
         Button btn1 = FindViewById<Button> (Resource.Id.button1);
         btn1.Click += HexButtonOnClick;
         Button btn2 = FindViewById<Button> (Resource.Id.button2);
         btn2.Click += HexButtonOnClick;
         Button btn3 = FindViewById<Button> (Resource.Id.button3);
         btn3.Click += HexButtonOnClick;
         Button btn4 = FindViewById<Button> (Resource.Id.button4);
         btn4.Click += HexButtonOnClick;
         Button btn5 = FindViewById<Button> (Resource.Id.button5);
         btn5.Click += HexButtonOnClick;
         Button btn6 = FindViewById<Button> (Resource.Id.button6);
         btn6.Click += HexButtonOnClick;
         Button btn7 = FindViewById<Button> (Resource.Id.button7);
         btn7.Click += HexButtonOnClick;
         Button btn8 = FindViewById<Button> (Resource.Id.button8);
         btn8.Click += HexButtonOnClick;
         Button btn9 = FindViewById<Button> (Resource.Id.button9);
         btn9.Click += HexButtonOnClick;
         Button btnA = FindViewById<Button> (Resource.Id.buttonA);
         btnA.Click += HexButtonOnClick;
         Button btnB = FindViewById<Button> (Resource.Id.buttonB);
         btnB.Click += HexButtonOnClick;
         Button btnC = FindViewById<Button> (Resource.Id.buttonC);
         btnC.Click += HexButtonOnClick;
         Button btnD = FindViewById<Button> (Resource.Id.buttonD);
         btnD.Click += HexButtonOnClick;
         Button btnE = FindViewById<Button> (Resource.Id.buttonE);
         btnE.Click += HexButtonOnClick;
         Button btnF = FindViewById<Button> (Resource.Id.buttonF);
         btnF.Click += HexButtonOnClick;

         btnDec = FindViewById<Button> (Resource.Id.buttonDec);
         btnDec.Click += ChangeModeOnClick;
         btnHex = FindViewById<Button> (Resource.Id.buttonHex);
         btnHex.Click += ChangeModeOnClick;

         Button btnAC = FindViewById<Button> (Resource.Id.buttonAllClear);
         btnAC.Click += BtnAC_Click;

         Button btnDel = FindViewById<Button> (Resource.Id.buttonDel);
         btnDel.Click += BtnDel_Click;

         Button btnEnter = FindViewById<Button> (Resource.Id.buttonEnter);
         btnEnter.Click += BtnEnter_Click;

         Button btnPlus = FindViewById<Button> (Resource.Id.buttonPlus);
         btnPlus.Click += BtnPlus_Click;

         Button btnMinus = FindViewById<Button> (Resource.Id.buttonMinus);
         btnMinus.Click += BtnMinus_Click;

         txtDec = FindViewById<TextView> (Resource.Id.textViewDec);
         txtHex = FindViewById<TextView> (Resource.Id.textViewHex);

         txtDec.Text = "0";
         txtHex.Text = "0";

         btnDec.SetBackgroundColor (Color.Yellow);
         btnDec.SetTextColor (Color.Black);
         btnHex.SetBackgroundColor (defaultBackColor);
         btnHex.SetTextColor (Color.White);

         defaultBackColor = btnHex.DrawingCacheBackgroundColor;

         txtDec.SetTextColor (Color.Yellow);
      }

      private void BtnMinus_Click (object sender, System.EventArgs e)
      {
         if (calculationStack.Count > 0)
         {
            Int64 num = calculationStack.Pop ();
            Int64 num2 = HexConverter.GetNumericString (txtDec.Text);
            txtDec.Text = (num - num2).ToString ("N0");
            txtHex.Text = HexConverter.ConvertDecToHex (txtDec.Text);
            entering = false;

            calculationStack.Push (num - num2);
         }
      }

      private void BtnPlus_Click (object sender, System.EventArgs e)
      {
         if (calculationStack.Count > 0)
         {
            Int64 num = calculationStack.Pop ();
            Int64 num2 = HexConverter.GetNumericString (txtDec.Text);
            txtDec.Text = (num + num2).ToString ("N0");
            txtHex.Text = HexConverter.ConvertDecToHex (txtDec.Text);
            entering = false;

            calculationStack.Push (num + num2);
         }
      }

      private void BtnEnter_Click (object sender, System.EventArgs e)
      {
         // Add to the stack
         Int64 num = HexConverter.GetNumericString (txtDec.Text);
         calculationStack.Push (num);
         entering = false;
      }

      private void BtnDel_Click (object sender, System.EventArgs e)
      {
         if (entering == true)
         {
            if (currentmode == EntryMode.Decimal)
            {
               txtDec.Text = txtDec.Text.Remove (txtDec.Text.Length - 1);
               txtDec.Text = HexConverter.GetNumericString (txtDec.Text).ToString ("N0");
               txtHex.Text = HexConverter.ConvertDecToHex (txtDec.Text);
            }
            else
            {
               txtHex.Text = txtHex.Text.Remove (txtHex.Text.Length - 1);
               txtHex.Text = HexConverter.PadHexString (txtHex.Text);
               txtDec.Text = HexConverter.ConvertHexToDec (txtHex.Text);
            }
         }
      }

      private void BtnAC_Click (object sender, System.EventArgs e)
      {
         txtDec.Text = "0";
         txtHex.Text = "0";
         calculationStack = new Stack<long> ();
         entering = false;
      }

      private void ChangeModeOnClick (object sender, System.EventArgs e)
      {
         Button button = (Button)sender;
         string pressed = button.Text;

         // Change the mode

         if (pressed.ToUpperInvariant () == "DEC")
         {
            currentmode = EntryMode.Decimal;
            btnDec.SetBackgroundColor (Color.Yellow);
            btnDec.SetTextColor (Color.Black);
            btnHex.SetBackgroundColor (defaultBackColor);
            btnHex.SetTextColor (Color.White);
            txtDec.SetTextColor (Color.Yellow);
            txtHex.SetTextColor (Color.White);
         }
         else
         {
            currentmode = EntryMode.Hex;
            btnDec.SetBackgroundColor (defaultBackColor);
            btnDec.SetTextColor (Color.White);
            btnHex.SetBackgroundColor (Color.Yellow);
            btnHex.SetTextColor (Color.Black);
            txtDec.SetTextColor (Color.White);
            txtHex.SetTextColor (Color.Yellow);
         }
      }

      private void HexButtonOnClick (object sender, System.EventArgs e)
      {
         Button button = (Button)sender;
         string pressed = button.Text;

         if (currentmode == EntryMode.Decimal)
         {
            // Make sure when if a hex digit is pressed first, it doesn't clear the display
            if ("0123456789".Contains(pressed) == false)
            {
               return;
            }
         }

         if (entering == false)
         {
            // First character, clear display

            txtDec.Text = "";
            txtHex.Text = "";
         }

         entering = true;

         if (currentmode == EntryMode.Decimal)
         {
            // Only accept 0-9

            if ("0123456789".Contains (pressed))
            {
               txtDec.Text += pressed;
               txtDec.Text = HexConverter.FormatNumericString (txtDec.Text);
               txtHex.Text = HexConverter.ConvertDecToHex (txtDec.Text);
            }
         }
         else
         {
            // Hex mode, everything goes
            txtHex.Text += pressed;
            txtHex.Text = HexConverter.PadHexString (txtHex.Text);
            txtDec.Text = HexConverter.ConvertHexToDec (txtHex.Text);
         }
      }
   }
}

