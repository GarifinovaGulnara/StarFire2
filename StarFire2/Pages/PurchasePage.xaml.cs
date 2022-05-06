using StarFire2;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarFire.Pages
{
    /// <summary>
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        Products products;
        //public int ID;
        public PurchasePage(Products prod)
        {
            //ID = id;
            InitializeComponent();
            //NumberProd.Text = ID.ToString();
            products = prod;
            NumberProd.Text = prod.ID_prod.ToString(); 
        }

        private void PurchasePageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NumberProd.Text == "" || Bust.Text == "" || Waist.Text == "" || Hips.Text == "" || LengtProd.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Orders order = new Orders();
                {
                    order.ID_prod = Convert.ToInt32(NumberProd.Text);
                    order.Bust = Convert.ToInt32(Bust.Text);
                    order.Waist = Convert.ToInt32(Waist.Text);
                    order.Hips = Convert.ToInt32(Hips.Text);
                    order.LenghtProd = Convert.ToInt32(LengtProd.Text);
                    order.ID_user = App.user.ID_user;
                    App.starFireEntities.SaveChanges();
                }
                App.starFireEntities.Orders.Add(order);
                App.starFireEntities.SaveChanges();
                MessageBox.Show("Ваш заказ отправлен");
            }
        }
    }
}
