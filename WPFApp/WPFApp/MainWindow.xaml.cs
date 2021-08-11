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
using Calculator;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        string operation = "";
        Calculator.Calculator calculator = new Calculator.Calculator();
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("0");

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("1");

        }




        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("2");

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("3");

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("4");

        }


        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("5");

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("6");

        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("7");

        }


        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("8");

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            NumButtonClicked("9");

        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            if (operation.Equals(""))
            {
                calculator.Num1 = 0;
                txtDisplay.Text = calculator.Num1.ToString();
            }

            else
            {
                calculator.Num2 = 0;
                txtDisplay.Text = calculator.Num2.ToString();
            }

        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            calculator.Num2 = 0;
            calculator.Num1 = 0;
            operation = "";
            txtDisplay.Text = "0";
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            double tempNum;
            if (Double.TryParse(txtDisplay.Text, out tempNum))
            {
                if (tempNum != 0)
                {
                    tempNum *= -1;
                    txtDisplay.Text = tempNum.ToString();
                }
            }
            
        }

        private void btnEq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            double num2;
            bool isNumerical = Double.TryParse(txtDisplay.Text, out num2);

            if (isNumerical)
            {
                calculator.Num2 = num2;
                switch (operation)
                {
                    case "+":
                        result = calculator.Add();
                        operation = "ANS";
                        break;
                    case "-":
                        result = calculator.Subtract();
                        operation = "ANS";
                        break;
                    case "X":
                        result = calculator.Multiply();
                        operation = "ANS";
                        break;
                    case "/":
                        if (calculator.Num2 > 0)
                        {
                            result = calculator.Divide();
                            operation = "ANS";
                        }
                        break;
                    case "%":
                        if (calculator.Num2 > 0)
                        {
                            result = calculator.Modulus();
                            operation = "ANS";
                        }
                        break;
                    default:
                        result = calculator.Num1;
                        operation = "ANS";
                        break;

                }
                if (operation.Equals("ANS"))
                {
                    txtDisplay.Text = result.ToString();
                    calculator.Num1 = result;
                    calculator.Num2 = 0;
                    operation = "";
                }

                else
                {
                    txtDisplay.Text = "Error";
                }
            }

        }

        private void MathsOperation(string op)
        {
            if (operation.Equals(""))
            {
                calculator.Num1 = Convert.ToDouble(txtDisplay.Text);
                operation = op;
                txtDisplay.Text = operation;
            }
            
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            MathsOperation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            MathsOperation("-");
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            MathsOperation("X");
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            MathsOperation("/");
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            MathsOperation("%");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {   
            //Check if any number input. Check if more than single digit. 
            if (!txtDisplay.Text.Equals(""))
            {
                if (txtDisplay.Text.Equals(operation))
                {
                    operation = "";
                    txtDisplay.Text = calculator.Num1.ToString();
                }
                else
                {
                    int len = txtDisplay.Text.Length;
                    txtDisplay.Text = txtDisplay.Text.Remove(len - 1);
                }



                //if (operation.Equals(""))
                //{
                //    txtDisplay.Text = calculator.Num1.ToString(input.Remove(input.Length - 1));
                //    if (input.Length == 1)
                //    {
                //        calculator.Num1 = 0;
                //        txtDisplay.Text = "";
                //    }
                //    else
                //    {
                //        txtDisplay.Text = calculator.Num1.ToString(input.Remove(input.Length - 1));
                //    }


                //}
                //else
                //{
                //    if (input.Length == 1)
                //    {
                //        calculator.Num2 = 0;
                //        txtDisplay.Text = "";
                //    }
                //    else
                //    {
                //        calculator.Num2 = Convert.ToDouble(txtDisplay.Text.Remove(input.Length - 1));
                //        txtDisplay.Text = calculator.Num2.ToString();
                //    }

                //}
            }

        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains('.'))
            {
                NumButtonClicked(".");
            }
        }

        public void NumButtonClicked(string num)
        {

            if (!txtDisplay.Text.Equals(operation) && (!txtDisplay.Text.Equals("0") || num.Equals(".")))
            {
                txtDisplay.Text += num.ToString();
            }
            else
            {
                txtDisplay.Text = num.ToString();
            }
        }

        public void NumButtonClicked(int num)
        {

            if (operation.Equals(""))
            {

                calculator.Num1 = (calculator.Num1 * 10) + num;
                txtDisplay.Text = calculator.Num1.ToString();
            }
            else
            {
                calculator.Num2 = (calculator.Num2 * 10) + num;
                txtDisplay.Text = calculator.Num2.ToString();
            }

        }
    }
}
