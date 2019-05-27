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
    /// Логика взаимодействия для AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        STOModelContext db = new STOModelContext();

        public AddCustomer()
        {
            InitializeComponent();
        }

        Customers AddPage;

        public AddCustomer(Customers a)
        {
            InitializeComponent();
            AddPage = a;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Customer newCustomer = new Model.Customer()
                {
                    Login = AddLogin.Text,
                    FIO = AddFIO.Text,
                    Phone = AddPhone.Text,
                    Adres = AddAdres.Text,
                    Person = AddPerson.Text
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (AddAdres.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите aдрес!\n";
            }
           
            else if (AddAdres.Text.Length < 3)
            {
                error = true;
                msgerror += "Адрес указан не верно!\n";
            }
            if (AddAdres.Text.Length > 100)
            {
                error = true;
                msgerror += "Адрес превышает максимальное количество символов(100)!\n";
            }

            if (AddFIO.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите ФИО!\n";
            }
           
            else if (AddFIO.Text.Length < 3)
            {
                error = true;
                msgerror += "ФИО указано не верно!\n";
            }
            if (AddFIO.Text.Length > 100)
            {
                error = true;
                msgerror += "ФИО превышает максимальное количество символов(100)!\n";
            }

            if (AddLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(AddLogin.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(AddLogin.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(AddLogin.Text)).FirstOrDefault();
                if ((user != null && master != null) || (user != null && customer != null) || master != null || customer != null)

                {
                    error = true;
                    msgerror += "Такой логин уже существует!\n";
                }
            }

            if (AddLogin.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите логин!\n";
            }
            else if (AddLogin.Text.Length < 4)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }

            if (AddLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }

           
          

            if (AddPhone.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите номер телефона!\n";
            }
            else if (AddPhone.Text.Length < 5)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (AddPhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }
            if (AddPerson.Text == String.Empty)
            {
                error = true;
                msgerror += "Выберите лицо!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

    }
}
