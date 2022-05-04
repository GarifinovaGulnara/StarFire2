using StarFire2.Windows;
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
using StarFire2.db;
using StarFire2;
using System.IO;

namespace StarFire.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        public ProfilPage()
        {
            InitializeComponent();
            GetInfoUsers();
        }

        public void GetInfoUsers()
        {
            FILb.Content = App.user.Users.Name + " " + App.user.Users.Surname;
            PhoneLb.Content = App.user.Phone;
            PassLb.Content = App.user.Password;
            ImgUser.Source = ByteArrayToImage(App.user.Users.Photo);
        }
        private void UpdateProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateProfilWindow update = new UpdateProfilWindow();
            update.Show();
        }

        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}
