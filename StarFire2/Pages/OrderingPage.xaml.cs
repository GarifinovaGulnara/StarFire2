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
    /// Логика взаимодействия для OrderingPage.xaml
    /// </summary>
    public partial class OrderingPage : Page
    {
        public OrderingPage()
        {
            InitializeComponent();
        }

        private void SendOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DesOrder.Text == "" || BustLb.Text == ""|| WaistLb.Text == "" || HipsLb.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Orders order = new Orders();
                {
                    order.Description = DesOrder.Text;
                    order.Bust = Convert.ToInt32(BustLb.Text);
                    order.Waist = Convert.ToInt32(WaistLb.Text);
                    order.Hips = Convert.ToInt32(HipsLb.Text);
                    order.LenghtProd = Convert.ToInt32(LengProd.Text);
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
