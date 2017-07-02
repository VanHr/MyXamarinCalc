using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCalc
{
    public partial class MainPage : ContentPage
    {
        enum SignType
        {
            PLUS = '+',
            MINUS = '-',
            PROD = '*',
            DIV = '/'
        };

        SignType sType;
        string inputStr = "";
        string leftStr = "";
        bool dot = false;
        bool sign = false;

        public MainPage()
        {
            InitializeComponent();
            Clear.Text = "<";
        }

        void OnNumberClicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            if (sign)
            {
                leftStr = inputStr;
                inputStr = "";
                sign = false;
            }

            inputStr += bt.Text;
            lbOut.Text = inputStr;
        }

        void OnDotClicked(object sender, EventArgs e)
        {
            if (dot)
            {
                return;
            }

            if (inputStr != "")
            {
                inputStr += ",";
                dot = true;
            }
            else
            {
                inputStr = "0,";
                dot = true;
            }

            lbOut.Text = inputStr;
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            if (inputStr.Length == 0)
            {
                return;
            }

            if (inputStr.Length == 1)
            {
                inputStr = "";
                lbOut.Text = "0";
                return;
            }

            inputStr = inputStr.Remove(inputStr.Length - 1);
            lbOut.Text = inputStr;
        }

        void OnAllClearClicked(object sender, EventArgs e)
        {
            if (inputStr.Length == 0)
            {
                return;
            }

            inputStr = "";
            leftStr = "";
            lbOut.Text = "0";
        }

        void OnSignClicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            if (sign)
            {
                return;
            }

            if (leftStr != "")
            {
                inputStr = (GetResult(leftStr, inputStr)).ToString();
                lbOut.Text = inputStr;
                leftStr = "";
            }

            switch (bt.Text)
            {
                case "+":
                    sType = SignType.PLUS;
                    break;
                case "-":
                    sType = SignType.MINUS;
                    break;
                case "*":
                    sType = SignType.PROD;
                    break;
                case "/":
                    sType = SignType.DIV;
                    break;
            }

            sign = true;
        }

        void OnEqualClicked(object sender, EventArgs e)
        {
            if (leftStr == "" || inputStr == "")
            {
                return;
            }
            double result = GetResult(leftStr, inputStr);
            inputStr = result.ToString();
            lbOut.Text = inputStr;

            leftStr = "";
        }

        void OnSinClicked(object sender, EventArgs e)
        {
            double op;

            double.TryParse(inputStr, out op);

            inputStr = (Math.Sin(op)).ToString();

            if (leftStr != "")
            {
                inputStr = (GetResult(leftStr, inputStr)).ToString();
            }

            lbOut.Text = inputStr;
        }

        void OnCosClicked(object sender, EventArgs e)
        {
            double op;

            double.TryParse(inputStr, out op);

            inputStr = (Math.Cos(op)).ToString();

            if (leftStr != "")
            {
                inputStr = (GetResult(leftStr, inputStr)).ToString();
            }

            lbOut.Text = inputStr;
        }

        void OnLnClicked(object sender, EventArgs e)
        {
            double op;

            double.TryParse(inputStr, out op);

            inputStr = (Math.Log(op, 2)).ToString();

            if (leftStr != "")
            {
                inputStr = (GetResult(leftStr, inputStr)).ToString();
            }

            lbOut.Text = inputStr;
        }

        void OnSqrClicked(object sender, EventArgs e)
        {
            double op;

            double.TryParse(inputStr, out op);

            inputStr = (op * op).ToString();

            if (leftStr != "")
            {
                inputStr = (GetResult(leftStr, inputStr)).ToString();
            }

            lbOut.Text = inputStr;
        }

        double GetResult(string lOp, string rOp)
        {
            double op1, op2;
            dot = false;

            double.TryParse(lOp, out op1);
            double.TryParse(rOp, out op2);

            switch (sType)
            {
                case SignType.PLUS:
                    return op1 + op2;
                case SignType.MINUS:
                    return op1 - op2;
                case SignType.PROD:
                    return op1 * op2;
                case SignType.DIV:
                    return op1 / op2;
                default:
                    return 0;
            }
        }
    }
}
