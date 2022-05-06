using Microsoft.Win32;
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
    /// Логика взаимодействия для AAddProductPage.xaml
    /// </summary>
    public partial class AAddProductPage : Page
    {
        byte[] photo;
        public AAddProductPage()
        {
            InitializeComponent();
            GetInfo();
        }

        public void GetInfo()
        {
            var gg = App.starFireEntities.TypeOfProducts.ToList();
            TypeProd.ItemsSource = gg;
            TypeProd.DisplayMemberPath = "Name";
        }
        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
        private void SelectionImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdImg = new OpenFileDialog();
            ofdImg.Filter = "Image files|*.bmp;*.jpg;*.png;*.tif|All files|*.*";
            ofdImg.FilterIndex = 1;
            if (ofdImg.ShowDialog() == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(ofdImg.FileName);
                img.EndInit();
                photo = File.ReadAllBytes(ofdImg.FileName);
                ImgProduct.Source = ByteArrayToImage(photo);
            }
        }

        private void SaveProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PriceProd.Text == "" || NameProduct.Text=="")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Products prod = new Products();
                {
                    //var gg = TypeProd.SelectedItem as Products;

                    //var id = (from i in App.starFireEntities.TypeOfProducts
                    //          where i.ID_type == gg.ID_type
                    //          select i).First();

                    prod.Name = NameProduct.Text;
                    prod.Price = Convert.ToInt32(PriceProd.Text);
                    prod.Description = DescriptionProduct.Text;
                    //prod.ID_type = id.ID_type;
                    prod.Photo = photo;
                    App.starFireEntities.SaveChanges();
                }
                App.starFireEntities.Products.Add(prod);
                App.starFireEntities.SaveChanges();
                MessageBox.Show("ok");
                NameProduct.Text = "";
                PriceProd.Text = "";
                DescriptionProduct.Text = "";
            }
        }
    }
}
