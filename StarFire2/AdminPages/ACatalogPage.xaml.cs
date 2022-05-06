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

namespace StarFire.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ACatalogPage.xaml
    /// </summary>
    public partial class ACatalogPage : Page
    {
        public int x = 1;
        public ACatalogPage()
        {
            InitializeComponent();
            GetInfoProd();
        }

        public void GetInfoProd()
        {
            var gg = App.starFireEntities.Products.ToList();
            ListProdCB.ItemsSource = gg;
            ListProdCB.DisplayMemberPath = "Name";
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
        private void AddProductPageBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AAddProductPage());
        }

        private void RightArrowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (x + 4 <= App.starFireEntities.Products.Count())
            {
                x += 4;
            }
            else
            {
                x = 1;
            }
            GetInfoProd();
        }

        private void DeleteProdactBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var gg = ListProdCB.SelectedItem as Products;
                var pro = (from pr in App.starFireEntities.Products
                           where pr.Name == gg.Name
                           select pr).First();
                var ph = (from pho in App.starFireEntities.Products
                          where pho.Name == gg.Name
                          select pho).First();

                App.starFireEntities.Products.Remove(pro);
                App.starFireEntities.Products.Remove(ph);
                App.starFireEntities.SaveChanges();
                MessageBox.Show("Продукт удaлен");
                GetInfoProd();

            }
            catch { }
        }

        private void LeftArrowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (x - 4 <= App.starFireEntities.Products.Count())
            {
                x -= 4;
            }
            else
            {
                x = 1;
            }
            GetInfoProd();
        }
    }
}
