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
using StarFire.Windows;
using StarFire2;
using StarFire2.db;

namespace StarFire.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogUpPage.xaml
    /// </summary>
    public partial class LogUpPage : Page
    {
        public LogUpPage()
        {
            InitializeComponent();
        }

        private void LogUpAppBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FIOLb.Text=="" || PhoneLb.Text == "" || PassLb.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users();
                {
                    us.Name = FIOLb.Text;
                }
                App.starFireEntities.Users.Add(us);
                App.starFireEntities.SaveChanges();
                Authorization aut = new Authorization();
                {
                    aut.Phone = PhoneLb.Text;
                    aut.Password = PassLb.Password;
                    aut.ID_role = 2;
                    aut.ID_user = us.ID_user;
                }
                App.starFireEntities.Authorization.Add(aut);
                App.starFireEntities.SaveChanges();
                MessageBox.Show("ok");


                AboutUsWindow aboutus = new AboutUsWindow();
                aboutus.Show();
                Application.Current.MainWindow.Close();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
