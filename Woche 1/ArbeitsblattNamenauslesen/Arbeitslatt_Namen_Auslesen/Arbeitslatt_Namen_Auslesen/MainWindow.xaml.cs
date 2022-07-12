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
using System.IO;

using Microsoft.Win32; //FileDialog
//-- < using > --          

namespace Arbeitslatt_Namen_Auslesen
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

        private void button4start_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;
            else
            {
                MessageBox.Show("Bitte Exceldatei auswählen");
            }
            Dateipfad.Text = filePath;
            string fileExtension = System.IO.Path.GetExtension(filePath);

            if (fileExtension == ".xlsx")
            {
                MessageBox.Show("Ihre Datei wird bearbeitet");
            }
            else
            {
                MessageBox.Show("Es sind nur Excel Dateien erlaubt");
            }
           
        } 
        
       
    }
}