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
using System.Windows.Shapes;
using StarFire.Pages;

namespace StarFire.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutUsWindow.xaml
    /// </summary>
    public partial class AboutUsWindow : Window
    {
        public AboutUsWindow()
        {
            InitializeComponent();
        }

        private void ProfilPageBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new ProfilPage());
        }

        private void EmploeePageBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new EmploeePage());
        }

        private void OrderPageBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new OrderingPage());
        }

        private void CatalogPageBtn_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new CatalogPage());
        }
    }
}
