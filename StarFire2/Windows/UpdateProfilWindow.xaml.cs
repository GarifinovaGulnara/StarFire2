using StarFire2.db;
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
using System.IO;
using Microsoft.Win32;
using StarFire;

namespace StarFire2.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateProfilWindow.xaml
    /// </summary>
    public partial class UpdateProfilWindow : Window
    {
        public static StarFireEntities dba = new StarFireEntities();
        byte[] photo;
        public UpdateProfilWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var us= App.starFireEntities.Users.Where(x => x.ID_user == App.user.ID_user).FirstOrDefault();
            us.Name = NewName.Text;
            us.Surname = NewSurname.Text;
            us.Photo = photo;
            App.starFireEntities.SaveChanges();
            var aut = App.starFireEntities.Authorization.Where(x => x.ID_user == App.user.ID_user).FirstOrDefault();
            aut.Phone = NewPhone.Text;
            aut.Password = NewPass.Password;
            App.starFireEntities.SaveChanges();
            this.Close();
        }

        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using(var stream =new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
        private void SelectedPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdImg = new OpenFileDialog();
            ofdImg.Filter = "Image files|*.bmp;*.jpg;*.png;*.tif|All files|*.*";
            ofdImg.FilterIndex = 1;
            if(ofdImg.ShowDialog() == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(ofdImg.FileName);
                img.EndInit();
                photo = File.ReadAllBytes(ofdImg.FileName);
                NewImg.Source = ByteArrayToImage(photo);
            }
        }
    }
}
