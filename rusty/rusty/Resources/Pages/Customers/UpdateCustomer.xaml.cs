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

namespace rusty.Resources.Pages.Customers
{
    /// <summary>
    /// Логика взаимодействия для UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {
        STOModelContext db = new STOModelContext();
        public string Login;
        public string FIO;
        public string Phone;
        public string Adres;
        public string Person;
        Customers Customer;
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public UpdateCustomer(string log, string fio,string phone, string adres, string person, Customers customer)
        {
            InitializeComponent();
            Login = log;
            FIO = fio;
            Phone = phone;
            Adres = adres;
            Person = person;
            Customer = customer;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {

                Model.Customer UpdateCustomer = (from customer in db.Customers
                                                 where (
                      customer.Login == Login &&
                      customer.FIO == FIO &&
                      customer.Phone == Phone &&
                      customer.Adres == Adres &&
                      customer.Person == Person
                      )
                                                 select customer).Single();
                if (UpdateLogin.Text != String.Empty)
                    UpdateCustomer.Login = UpdateLogin.Text;
                if (UpdateFIO.Text != String.Empty)
                    UpdateCustomer.FIO = UpdateFIO.Text;
                if (UpdatePhone.Text != String.Empty)
                    UpdateCustomer.Phone = UpdatePhone.Text;
                if (UpdateAdres.Text != String.Empty)
                    UpdateCustomer.Adres = UpdateAdres.Text;
                if (UpdatePerson.Text != String.Empty)
                    UpdateCustomer.Person = UpdatePerson.Text;
                db.SaveChanges();
                Customers.a.ItemsSource = db.Customers.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

          

            if (UpdateAdres.Text.Length < 3 && UpdateAdres.Text != String.Empty)
            {
                error = true;
                msgerror += "Адрес указан не верно!\n";
            }
            if (UpdateAdres.Text.Length > 100)
            {
                error = true;
                msgerror += "Адрес превышает максимальное количество символов(100)!\n";
            }

            
            
            if (UpdateFIO.Text.Length < 3 && UpdateFIO.Text != String.Empty)
            {
                error = true;
                msgerror += "ФИО указано не верно!\n";
            }
            if (UpdateFIO.Text.Length > 100)
            {
                error = true;
                msgerror += "ФИО превышает максимальное количество символов(100)!\n";
            }

            if (UpdateLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(UpdateLogin.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(UpdateLogin.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(UpdateLogin.Text)).FirstOrDefault();
                if ((user != null && master != null) || (user != null && customer != null) || master != null || customer != null)

                {
                    error = true;
                    msgerror += "Такой логин уже существует!\n";
                }
            }

           if (UpdateLogin.Text.Length < 4 && UpdateLogin.Text != String.Empty)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }

            if (UpdateLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }



            
            else if (UpdatePhone.Text.Length < 5 && UpdatePhone.Text != String.Empty)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (UpdatePhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }
           

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка обновления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

    }
}
