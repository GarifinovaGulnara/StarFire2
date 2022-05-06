using StarFire2;
using StarFire2.db;
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

namespace StarFire.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AOrdersPage.xaml
    /// </summary>
    public partial class AOrdersPage : Page
    {
        public AOrdersPage()
        {
            InitializeComponent();
            GetOrders();
        }

        public void GetOrders()
        {

            AllOrderLV.ItemsSource = App.starFireEntities.Orders.ToList();

            //var ph4 = (from cust in App.starFireEntities.Orders
            //           join ph in App.starFireEntities.Users on cust.ID_user equals ph.ID_user
            //           join au in App.starFireEntities.Authorization on ph.ID_user equals au.ID_user
            //           select new
            //           {
            //               ID_order = cust.ID_order,
            //               Description = cust.Description,
            //               Name = ph.Name,
            //               LenghtProd = cust.LenghtProd,
            //               Phone = au.Phone,
            //               Bust = cust.Bust,
            //               Waist = cust.Waist,
            //               Hips = cust.Hips,
            //               Ready = cust.Ready
            //           }).ToList();
            //AllOrderLV.ItemsSource = ph4;
        }

        private void AllOrderLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DialogWindow dia = new DialogWindow();
            if (dia.ShowDialog()==true)
            {
                var item = AllOrderLV.SelectedItem as Orders;
                var t = App.starFireEntities.Orders.Where(x => x.ID_order == item.ID_order).FirstOrDefault();
                t.Ready = !t.Ready;
                App.starFireEntities.SaveChanges();
                GetOrders();
            }
            else
            {
                dia.Close();
            }
        }
    }
}
