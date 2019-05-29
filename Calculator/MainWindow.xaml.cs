using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{


    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public StringBuilder input = new StringBuilder();
        public StringBuilder calcs = new StringBuilder();
        public double result = 0;
        public double inputValue = 0;
        public int op = 0;
        public bool start = true;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void calculation()
        {
            
            switch (op)
            {
                case 1:
                    {
                        result += inputValue;
                        break;
                    }
                case 2:
                    {
                        result -= inputValue;
                        break;
                    }
                case 3:
                    {
                        result *= inputValue;
                        break;
                    }
                case 4:
                    {
                        result /= inputValue;
                        break;
                    }

                case 5:
                    {
                        var par = (result * inputValue) / 100;
                        result += par;
                        break;
                    }
                case 6:
                    {
                        var par = (result * inputValue) / 100;
                        result -= par;
                        break;
                    }
            }

            resultText.Text = result.ToString();
            calcsText.Text = calcs.ToString();
            valueText.Text = "0";
        }

        private void init()
        {
            valueText.Text = "0";
            input.Clear();
            calcs.Clear();
            result = 0;
            inputValue = 0;
            op = 0;
            calcsText.Text = "0";
            start = true;
        }

        private void clickNumbers(object sender, RoutedEventArgs e)
        {
            var btn = ((Button)sender).Content;

            input.Append(btn);

            valueText.Text = input.ToString();

        }


        private void clickFunctions(object sender, RoutedEventArgs e)
        {
            var btn = ((Button)sender).Name;

            valueText.Text = "0";

            if(input.ToString() == string.Empty)
            {
                return;
            }

            if (start)
            {
                result = int.Parse(input.ToString());
                start = false;
            }

            inputValue = int.Parse(input.ToString());

            calcs.Append(input);
            input.Clear();


            switch (btn)
            {
                case "plusminus":
                    {

                        break;
                    }
                case "equal":
                    {
                        calculation();
                        calcs.Append("=");
                        start = true;
                        break;
                    }
                case "plus":
                    {
                        op = 1;
                        calcs.Append("+");
                        break;
                    }
                case "minus":
                    {
                        op = 2;
                        calcs.Append("-");
                        break;
                    }
                case "times":
                    {
                        op = 3;
                        calcs.Append("x");
                        break;
                    }
                case "divided":
                    {
                        op = 4;
                        calcs.Append("÷");
                        break;
                    }
                case "clear":
                    {
                        init();
                        calcsText.Text = calcs.ToString();
                        return;
                    }
                case "clearEntry":
                    {
                        valueText.Text = "0";
                        input.Clear();
                        calcsText.Text = calcs.ToString();
                        return;
                    }
                case "perPlus":
                    {
                        op = 5;
                        calcs.Append("%+");
                        break;
                    }
                case "perMinus":
                    {
                        op = 6;
                        calcs.Append("%-");
                        break;
                    }
            }

            calcsText.Text = calcs.ToString();


        }
    }
}
