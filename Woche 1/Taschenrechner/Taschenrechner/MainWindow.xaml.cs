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

namespace Taschenrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "1";

        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "9";
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "+";
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "-";
        }



        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "0";

        }

        private void ENTF_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text = "";

        }

        private void Button_mal_Click(object sender, RoutedEventArgs e)

        {
            Anzeigetafel.Text = Anzeigetafel.Text + "*";

        }

        private void Button_divi_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text + "/";
        }
        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {


            while (true)
            {
                //Erste Nummer
                int posFirstNumber = -1;
                int posFirstNumberEnd = -1;
                int firstNumber = 0;
                bool firstNumberFound = false;

                //Zweite Nummer
                int posSecondNumber = -1;
                int posSecondNumberEnd = 0;
                int secondNumber = 0;
                bool secondNumberFound = false;

                char op = '-';

                for (int pos = posSecondNumberEnd; pos <= Anzeigetafel.Text.Length - 1; pos++)
                {

                   

                        if (posFirstNumber < 0)
                    {
                        posFirstNumber = pos;
                    }

                  
                    
                    if (!Char.IsDigit(Anzeigetafel.Text[pos]))
                    {
                        if (!firstNumberFound)
                        {
                            
                            posFirstNumberEnd = pos - 1;
                            firstNumber = Convert.ToInt32(Anzeigetafel.Text.Substring(posFirstNumber, posFirstNumberEnd - posFirstNumber + 1));
                            firstNumberFound = true;
                             
                            op = Anzeigetafel.Text[pos];
                            posSecondNumber = pos + 1;



                            
                        }
                        else if (!secondNumberFound)
                        {
                            posSecondNumberEnd = pos - 1;
                            secondNumber = Convert.ToInt32(Anzeigetafel.Text.Substring(posSecondNumber, posSecondNumberEnd - posSecondNumber + 1));
                            secondNumberFound = true;
                            break;
                        }

                    }
                }

                if (posSecondNumber > posSecondNumberEnd)
                {
                    posSecondNumberEnd = Anzeigetafel.Text.Length - 1;
                    secondNumber = Convert.ToInt32(Anzeigetafel.Text.Substring(posSecondNumber, Anzeigetafel.Text.Length - posSecondNumber));
                }

                
                
                int result = -1;
                switch (op)
                {
                    case '-':
                        result = firstNumber - secondNumber;
                        break;
                    case '+':
                        result = firstNumber + secondNumber;
                        break;

                    case '*':
                        result = firstNumber * secondNumber;
                        break;

                    case '/':
                        result = firstNumber / secondNumber;
                       
                        break;

                        



                }

                string operation = Anzeigetafel.Text.Substring(posFirstNumber, posSecondNumberEnd - posFirstNumber + 1);

                Anzeigetafel.Text = Anzeigetafel.Text.Replace(operation, result.ToString());

                if (Anzeigetafel.Text.All(x => Char.IsDigit(x)))
                {
                    break;
                }

            }
            /*
            string[] result = Anzeigetafel.Text.Split();
            int numberOne = Convert .ToInt32(result[0]);
            int numberTwo = Convert.ToInt32(result[2]);
            string arithnethic = result[1];

            if (arithnethic == "+")    
            {
                int additionResult = numberOne + numberTwo;
                Anzeigetafel.Text = additionResult.ToString();

            }
            if (arithnethic == "-")
            {
                int subtractionResult = numberOne - numberTwo;
                Anzeigetafel.Text = subtractionResult.ToString();

            }*/
        }




    }
}
