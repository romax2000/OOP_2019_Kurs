using rusty.Resources.Model;
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

namespace rusty.Resources.Pages.Orders
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        STOModelContext db = new STOModelContext();

        public AddOrder()
        {
            InitializeComponent();
        }

        Orders AddPage;

        public AddOrder(Orders a)
        {
            InitializeComponent();
            AddPage = a;
            Combobox();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                //string namecustumer = AddCustomer.Text;
                string namemaster = AddMaster.Text;
                //AddCustomer.DisplayMemberPath = "CustomerId";
                AddRequest.DisplayMemberPath = "RequestId";
                AddMaster.DisplayMemberPath = "MasterId";
                Model.Order newOrder = new Model.Order()
                {
                    //CustomerId = Int32.Parse(AddCustomer.Text),
                    RequestId = Int32.Parse(AddRequest.Text),
                    MasterId = Int32.Parse(AddMaster.Text),
                    Status = AddStatus.Text,
                    Start = DateTime.Now,
                    //CustomerName = namecustumer,
                    MasterName = namemaster
                };

                int ID = Int32.Parse(AddRequest.Text);
                var StorageID = (from parht in db.Requests
                                 where (parht.RequestId == ID)
                                 select parht.StorageId).First();
                int idstorage = StorageID;
                var storageCost = (from parht in db.Storages
                                   where (parht.StorageId == idstorage)
                                   select parht.Cost).First();
                var ServiceID = (from parht in db.Requests
                                 where (parht.RequestId == ID)
                                 select parht.ServiceId).First();
                int idservice = ServiceID;
                var serviceCost = (from parht in db.Services
                                   where (parht.ServiceId == idservice)
                                   select parht.Cost).First();
                newOrder.Cast = serviceCost + storageCost;
                var Spec = (from parht in db.Requests
                            where (parht.RequestId == ID)
                            select parht.Specification).First();
                newOrder.Specification = Spec;
                var currentCustomerId = (from parht in db.Requests
                                         where (parht.RequestId == ID)
                                         select parht.CustomerId).First();
                newOrder.CustomerId = currentCustomerId;
                var currentCustomerName = (from parht in db.Requests
                                           where (parht.RequestId == ID)
                                           select parht.CustomerName).First();
                newOrder.CustomerName = currentCustomerName;
                if (newOrder.Status == "Готово")
                {
                    newOrder.Finish = Convert.ToString(DateTime.Now);
                }
                else
                {
                    newOrder.Finish = "В процессе";
                }
                if (newOrder.Status == String.Empty)
                {
                    newOrder.Status = "Принято";
                }
                db.Orders.Add(newOrder);
                db.SaveChanges();
                Orders.a.ItemsSource = db.Orders.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (AddRequest.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите номер заявки!\n";
            }

            if (AddMaster.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите мастера!\n";
            }


            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        public void Combobox()
        {
            //AddCustomer.ItemsSource = db.Customers.ToList();
            AddRequest.ItemsSource = db.Requests.ToList();
            AddMaster.ItemsSource = db.Masters.ToList();
        }
    }
}
