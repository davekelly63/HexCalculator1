using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace HexCalculator1
{
   enum EntryMode
   {
      Decimal,
      Hex
   };

   [Activity (Label = "HexCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
   public class MainActivity : Activity
   {
      TextView txtDec = null;
      TextView txtHex = null;

      EntryMode currentmode = EntryMode.Decimal;

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

         Button btnDec = FindViewById<Button> (Resource.Id.buttonDec);
         btnDec.Click += ChangeModeOnClick;
         Button btnHex = FindViewById<Button> (Resource.Id.buttonHex);
         btnHex.Click += ChangeModeOnClick;

         txtDec = FindViewById<TextView> (Resource.Id.textViewDec);
         txtHex = FindViewById<TextView> (Resource.Id.textViewHex);

         txtDec.Text = "0";
         txtHex.Text = "0";
      }

      private void ChangeModeOnClick (object sender, System.EventArgs e)
      {
         Button button = (Button)sender;
         string pressed = button.Text;

         // Change the mode

         if (pressed == "DEC")
         {
            currentmode = EntryMode.Hex;
         }
         else
         {
            currentmode = EntryMode.Decimal;
         }
      }

      private void HexButtonOnClick (object sender, System.EventArgs e)
      {
         Button button = (Button)sender;
         string pressed = button.Text;

         if (currentmode == EntryMode.Decimal)
         {
            // Only accept 0-9

            if ("0123456789".Contains(pressed))
            {
               txtDec.Text += pressed;
               txtHex.Text = HexConverter.ConvertDecToHex (txtDec.Text);
            }
         }
         else
         {
            // Hex mode, everything goes
            txtHex.Text += pressed;
            txtDec.Text = HexConverter.ConvertHexToDec (txtHex.Text);
         }


      }

   }


}

