using StarFire2;
using StarFire2.db;
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
            StarFire2.db.Products prod = new StarFire2.db.Products();
            try
            {
                var lst1 = from cust in App.starFireEntities.Products
                           where cust.ID_prod == x
                           select cust;
                var lst2 = from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 1
                           select cust;
                var lst3 = from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 2
                           select cust;
                var lst4 = from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 3
                           select cust;

                NumberOrderLab1.Content = lst1.First().ID_prod;
                Des1.Text = lst1.First().Description;
                PrProd1.Content = lst1.First().Price;

                NumberOrderLab2.Content = lst2.First().ID_prod;
                Des2.Text = lst2.First().Description;
                PrProd2.Content = lst2.First().Price;

                NumberOrderLab3.Content = lst3.First().ID_prod;
                Des3.Text = lst3.First().Description;
                PrProd3.Content = lst3.First().Price;

                NumberOrderLab4.Content = lst4.First().ID_prod;
                Des4.Text = lst4.First().Description;
                PrProd4.Content = lst4.First().Price;

                var ph1 = (from cust in App.starFireEntities.Products
                           where cust.ID_prod == x
                           select cust.Photo).First();

                var ph2 = (from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 1
                           select cust.Photo).First();

                var ph3 = (from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 2
                           select cust.Photo).First();

                var ph4 = (from cust in App.starFireEntities.Products
                           where cust.ID_prod == x + 3
                           select cust.Photo).First();

                img1.Source = ByteArrayToImage(ph1);
                img2.Source = ByteArrayToImage(ph2);
                img3.Source = ByteArrayToImage(ph3);
                img4.Source = ByteArrayToImage(ph4);
            }
            catch { }
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
