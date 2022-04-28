﻿using System;
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
using StarFire2.db;

namespace StarFire.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public static StarFireEntities dba = new StarFireEntities();
        public LogInPage()
        {
            InitializeComponent();
        }

        public static StarFire2.db.Authorization authUser;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void InAppBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneTB.Text == "" || PassTB.Password=="")
            {
                MessageBox.Show("");
            }
            foreach(var user in dba.Authorization)
            {
                if (user.Password == PassTB.Password.Trim() && user.ID_role==2)
                {
                    MessageBox.Show($"{user.Phone}");
                    AboutUsWindow aboutus = new AboutUsWindow();
                    aboutus.Show();
                    Application.Current.MainWindow.Close();
                }

                if (user.Password == PassTB.Password.Trim() && user.ID_role == 1)
                {
                    MessageBox.Show($"{user.Phone}");
                    AboutUsWindow aboutus = new AboutUsWindow();
                    aboutus.Show();
                    Application.Current.MainWindow.Close();
                }
            }
            
        }
    }
}
