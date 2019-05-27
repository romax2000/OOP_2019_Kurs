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
    /// Логика взаимодействия для UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
       STOModelContext db = new STOModelContext();
        //public int CustomerId;
        public int RequestId;
        public int MasterId;
        public string FinishD;
        public string Specification;
        public string Status;
        //public string CustomerName;
        public string MasterName;
        public Single Cast;
        Orders Order;
        public UpdateOrder()
        {
            InitializeComponent();
        }
       
        public UpdateOrder(/*int customer,*/ int request, int master, string finish, string specification, string status, Single cast,/* string customern,*/ string mastern, Orders order)
        {
            InitializeComponent();
            //CustomerId = customer;
            RequestId = request;
            MasterId = master;
           
            FinishD = finish;
            Specification = specification;
            Status = status;
            Cast = cast;
            //CustomerName = customern;
            MasterName = mastern;
            Order = order;
            Combobox();

        }
        public void Combobox()
        {
            //UpdateCustomer.ItemsSource = db.Customers.ToList();
            UpdateRequest.ItemsSource = db.Requests.ToList();
            UpdateMaster.ItemsSource = db.Masters.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //string customername = UpdateCustomer.Text;
            string mastername = UpdateMaster.Text;
            //UpdateCustomer.DisplayMemberPath = "CustomerId";
            UpdateRequest.DisplayMemberPath = "RequestId";
            UpdateMaster.DisplayMemberPath = "MasterId";
            Model.Order UpdateOrder = (from order in db.Orders where (
                                         //order.CustomerId == CustomerId &&
                                         order.RequestId == RequestId &&
                                         order.MasterId == MasterId && 
                                         order.Finish == FinishD &&
                                         order.Specification == Specification&&
                                         order.Status == Status&&
                                         order.Cast ==Cast &&
                                         //order.CustomerName == CustomerName &&
                                         order.MasterName == MasterName
                                         ) select order).Single();
            //if (UpdateCustomer.Text != String.Empty)
            //{
            //    UpdateOrder.CustomerId = Int32.Parse(UpdateCustomer.Text);
            //    UpdateOrder.CustomerName = customername;
            //}
            if (UpdateRequest.Text != String.Empty)
                UpdateOrder.RequestId = Int32.Parse(UpdateRequest.Text);
            if (UpdateMaster.Text != String.Empty)
            {
                UpdateOrder.MasterId = Int32.Parse(UpdateMaster.Text);
                UpdateOrder.MasterName = mastername;
            }
            if (UpdateStatus.Text != String.Empty)
                UpdateOrder.Status = UpdateStatus.Text;
            if (UpdateOrder.Status == "Готово")
            {
                UpdateOrder.Finish = Convert.ToString(DateTime.Now);
            }
            else
            {
                UpdateOrder.Finish = "В процессе";
            }
            if (UpdateSpecification.Text != String.Empty)
                UpdateOrder.Specification = UpdateSpecification.Text;
            if (UpdateRequest.Text != String.Empty)
            {
                int ID = Int32.Parse(UpdateRequest.Text);
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
                UpdateOrder.Cast = serviceCost + storageCost;
            }
            db.SaveChanges();
            Orders.a.ItemsSource = db.Orders.ToList();
            this.Hide();
        }
    }
}
