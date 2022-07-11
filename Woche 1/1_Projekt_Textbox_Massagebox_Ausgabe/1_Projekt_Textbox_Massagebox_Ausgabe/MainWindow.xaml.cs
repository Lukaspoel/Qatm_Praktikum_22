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

namespace _1_Projekt_Textbox_Massagebox_Ausgabe
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

        private void txtAusgabe_TextChanged(object sender, TextChangedEventArgs e)  
        {

        }

        private void KlickHere_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtInputOutput.Text);

        }
    }
}
