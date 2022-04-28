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

namespace StarFire.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ACatalogPage.xaml
    /// </summary>
    public partial class ACatalogPage : Page
    {
        public ACatalogPage()
        {
            InitializeComponent();
        }

        private void AddProductPageBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AAddProductPage());
        }
    }
}
