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
            Anzeigetafel.Text = Anzeigetafel.Text + " + ";
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        { 
            Anzeigetafel.Text = Anzeigetafel.Text + " - ";
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
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

            }
        }

       
            
            private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            Anzeigetafel.Text = Anzeigetafel.Text = "0";



        }
    }
}
