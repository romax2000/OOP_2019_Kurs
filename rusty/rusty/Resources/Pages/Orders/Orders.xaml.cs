using rusty.Resources.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace rusty.Resources.Pages.Orders
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Orders : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Orders()
        {
            InitializeComponent();
            db = new STOModelContext();
            orderGrid.ItemsSource = db.Orders.ToList();
            a = orderGrid;
            if (MainWindow.current_user == "user")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                UpdateStatus.Visibility = Visibility.Collapsed;
                OrderId.Visibility = Visibility.Collapsed;
                CustomerId.Visibility = Visibility.Collapsed;
                MasterId.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                OrderId.Visibility = Visibility.Collapsed;
            }
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddOrder addOrder = new AddOrder(this);
            addOrder.Topmost = true;
            addOrder.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
         //int CustomerId;
         int RequestId;
         int MasterId;
         string FinishD;
         string Specification;
         string Status;
            //string CustomerName;
            string MasterName;
         Single Cast;
            if (orderGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < orderGrid.SelectedItems.Count; i++)
                {
                    Model.Order order = orderGrid.SelectedItems[i] as Model.Order;
                    //CustomerId = order.CustomerId;
                    RequestId = order.RequestId;
                    MasterId = order.MasterId;
                    Specification = order.Specification;
                    Status = order.Status;
                    FinishD = order.Finish;
                    Cast = order.Cast;
                    //CustomerName = order.CustomerName;
                    MasterName = order.MasterName;
                    UpdateOrder update = new UpdateOrder(/*CustomerId,*/RequestId , MasterId,FinishD,Specification,Status,Cast, /*CustomerName,*/ MasterName,this);
                        update.Topmost = true;
                        update.Show();
                }
            }
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка изменения", "Запись является пустой", MessageBoxButton.OK);
            }
        }

        private void Delete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int? Id = (orderGrid.SelectedItem as Model.Order).OrderId;
                var deleteOrder = db.Orders.Where(db => db.OrderId == Id).FirstOrDefault();
                db.Orders.Remove(deleteOrder);
                db.SaveChanges();
                orderGrid.ItemsSource = db.Orders.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }

        private void UpdateStatus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            string Status = "Готово";
            string date = Convert.ToString(DateTime.Now);
            if (orderGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < orderGrid.SelectedItems.Count; i++)
                {
                    Model.Order order = orderGrid.SelectedItems[i] as Model.Order;
                    order.Status = Status;
                    order.Finish = date;
                }
                
            }

            db.SaveChanges();
            orderGrid.ItemsSource = db.Orders.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка изменения", "Запись является пустой", MessageBoxButton.OK);
            }
        }

    }
}
