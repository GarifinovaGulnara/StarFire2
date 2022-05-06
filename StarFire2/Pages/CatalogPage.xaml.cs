using StarFire2;
using StarFire2.db;
using StarFire2.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace StarFire.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public int b = 0;
        public CatalogPage()
        {
            InitializeComponent();
            GetInfoProd();
        }

        public void GetInfoProd()
        {
            //List<ProdModel> prodModels = new List<ProdModel>();
            //var prods = App.starFireEntities.Products.ToList();
            //foreach (var prod in prods)
            //{
            //    ProdModel prodModel = new ProdModel();
            //    prodModel.Id = prod.ID_prod;
            //    prodModel.Name = prod.Name;
            //    prodModel.Photo = ByteArrayToImage(prod.Photo);
            //    prodModel.Price = prod.Price;
            //    prodModel.Description = prod.Description;
            //    prodModels.Add(prodModel);
            //}
            //listprod.ItemsSource = prodModels;
            listprod.ItemsSource = App.starFireEntities.Products.ToList();
        }

        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        private void listprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gg = listprod.SelectedItem as Products;

            this.NavigationService.Navigate(new PurchasePage(gg));
        }

        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            //foreach(var fil in App.starFireEntities.Products)
            //{
            //    if (fil.Price == Convert.ToInt32(OtPrice.Text.Trim()) && fil.Price == Convert.ToInt32(DoPrice.Text.Trim()))
            //    {
            //        b++;
            //        listprod.SelectedItem = App.starFireEntities.Products.Where(x => x.Price == Convert.ToInt32(OtPrice.Text) && x.Price == Convert.ToInt32(DoPrice.Text));
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error");
            //    }
            //}
        }
    }
}
