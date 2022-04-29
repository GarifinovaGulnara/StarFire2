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
using StarFire.AdminPages;
using StarFire.Pages;
using StarFire2;
using StarFire2.db;

namespace StarFire.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutUsWindow.xaml
    /// </summary>
    public partial class AboutUsWindow : Window
    {
        public int ID;
        public AboutUsWindow(int id)
        {
            InitializeComponent();
            ID = id;
            if (ID==1)
            {
                ProfilPageBtn.Visibility = Visibility.Hidden;
            }
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
                if (App.user.ID_role == 1)
                {
                    SecondFrame.Navigate(new AOrdersPage());
                }
                else
                {
                    SecondFrame.Navigate(new OrderingPage());
                }
        }

        private void CatalogPageBtn_Click(object sender, RoutedEventArgs e)
        {
                if (App.user.ID_role == 1)
                {
                    SecondFrame.Navigate(new ACatalogPage());
                }
                else
                {
                    SecondFrame.Navigate(new CatalogPage());
                }
        }
    }
}
