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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text.Length < 2)
            {
                MessageBox.Show("Въведеното потребителско име е под 2 символа. Моля, опитайте пак.");
            } else
            {
                string s = "";
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        s = s + ((TextBox)item).Text + Environment.NewLine;
                    }
                }
                MessageBox.Show("Здрасти " + s + "!!! \nТова е твоята първа програма на Visual Studio 2015!");
            }
        }

        private void btnN_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtN.Text);
            int factoriel = n;
            if(n!=0)
            {
                for(int i=n-1; i>0; i--)
                {
                    factoriel = factoriel * i;
                }
                MessageBox.Show("n!= " + factoriel.ToString());
            }
        }

        private void btnNy_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtNy.Text);
            int y = int.Parse(txtY.Text);
            int squaring = n;
            for (int i = 1; i <= y; i++)
            {
                squaring = squaring * n;
            }
            MessageBox.Show("n square y " + squaring.ToString());
        }

        private void userIsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(mainWindow, "Сигурни ли сте, че искате да затворите програмата?", "Внимание!", MessageBoxButton.YesNo)==MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
