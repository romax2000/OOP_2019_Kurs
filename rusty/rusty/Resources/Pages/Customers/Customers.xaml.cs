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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rusty.Resources.Pages.Customers
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Customers()
        {
            InitializeComponent();
            db = new STOModelContext();
            customerGrid.ItemsSource = db.Customers.ToList();
            a = customerGrid;
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Collapsed;

            }
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer(this);
            addCustomer.Topmost = true;
            addCustomer.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            string Login;
            string FIO;
            string Phone;
            string Adres;
            string Person;

            if (customerGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < customerGrid.SelectedItems.Count; i++)
                {
                    Model.Customer customer = customerGrid.SelectedItems[i] as Model.Customer;

                    Login = customer.Login;
                    FIO = customer.FIO;
                    Phone = customer.Phone;
                    Adres = customer.Adres;
                    Person = customer.Person;
                    UpdateCustomer update = new UpdateCustomer(Login,FIO,Phone,Adres,Person,this);
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
                int? Id = (customerGrid.SelectedItem as Model.Customer).CustomerId;
                var deleteCustomer = db.Customers.Where(db => db.CustomerId == Id).FirstOrDefault();
                db.Customers.Remove(deleteCustomer);
                db.SaveChanges();
                customerGrid.ItemsSource = db.Customers.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
