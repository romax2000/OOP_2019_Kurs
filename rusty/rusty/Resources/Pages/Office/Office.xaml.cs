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

namespace rusty.Resources.Pages.Office
{
    /// <summary>
    /// Логика взаимодействия для Office.xaml
    /// </summary>
    public partial class Office : Page
    {
        STOModelContext db = new STOModelContext();
        string MyLog = MainWindow.current_login;
        string Password;
        string FIO;
        string Phone;
        string Adres;
        string Face;
        public Office()
        {
            InitializeComponent();

            Password = (from customers in db.Users
                        where (customers.Lonin == MyLog)
                        select customers.Password).First();
            FIO = (from customers in db.Customers
                   where (customers.Login == MyLog)
                   select customers.FIO).First();
            Phone = (from customers in db.Customers
                     where (customers.Login == MyLog)
                     select customers.Phone).First();
            Face = (from customers in db.Customers
                        where (customers.Login == MyLog)
                        select customers.Person).First();
            Adres = (from customers in db.Customers
                          where (customers.Login == MyLog)
                          select customers.Adres).First();
            MyLogin.Text = MyLog;
            MyPassword.Text = Password;
            MyFIO.Text = FIO;
            MyPhone.Text = Phone;
            MyAdres.Text = Adres;
            MyFace.Text = Face;
        }

        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ValidateForm())
            {
                string MLogin = MyLog;
                string MFIO = FIO;
                string MPhone = Phone;
                string MPassword = Password;
                string MAdres = Adres;
                string MFace = Face;
                Model.Customer UpdateCustomer = (from customer in db.Customers
                                                 where (
                      customer.Login == MyLog &&
                      customer.FIO == MFIO &&
                      customer.Phone == MPhone &&
                      customer.Adres == MAdres &&
                      customer.Person == MFace

                      )
                                                 select customer).Single();

                Model.User UpdateUser = (from customer in db.Users
                                         where (
                                         customer.Lonin == MyLog &&
                                         customer.Password == Password
                                         )
                                         select customer).Single();
                //if (MyLog != MyLogin.Text || Password != MyPassword.Text)

                UpdateCustomer.Login = MyLogin.Text;
                UpdateUser.Lonin = MyLogin.Text;
                UpdateUser.Password = MyPassword.Text;
                MainWindow.current_login = MyLogin.Text;
                MyLog = MyLogin.Text;
                Password = MyPassword.Text;
                //if (UpdateLogin.Text != String.Empty)

                //if (UpdateFIO.Text != String.Empty)
                UpdateCustomer.FIO = MyFIO.Text;
                //if (UpdatePhone.Text != String.Empty)
                UpdateCustomer.Phone = MyPhone.Text;
                UpdateCustomer.Person = MyFace.Text;
                UpdateCustomer.Adres = MyAdres.Text;
                db.SaveChanges();
            }
        }


        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (MyAdres.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите aдрес!\n";
            }

            else if (MyAdres.Text.Length < 3)
            {
                error = true;
                msgerror += "Адрес указан не верно!\n";
            }
            if (MyAdres.Text.Length > 100)
            {
                error = true;
                msgerror += "Адрес превышает максимальное количество символов(100)!\n";
            }

            if (MyFIO.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите ФИО!\n";
            }
           
            else if (MyFIO.Text.Length < 3)
            {
                error = true;
                msgerror += "ФИО указано не верно!\n";
            }
            if (MyFIO.Text.Length > 100)
            {
                error = true;
                msgerror += "ФИО превышает максимальное количество символов(100)!\n";
            }

            if (MyLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(MyLogin.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(MyLogin.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(MyLogin.Text)).FirstOrDefault();
                if (user != null || master != null || customer != null)
                {
                    if (user.Lonin != MainWindow.current_login)
                    {
                        error = true;
                        msgerror += "Такой логин уже существует!\n";
                    }
                }
            }

            if (MyLogin.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите логин!\n";
            }
            else if (MyLogin.Text.Length < 4)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }

            if (MyLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }

            if (MyPassword.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите пароль!\n";
            }
            else if (MyPassword.Text.Length < 4)
            {
                error = true;
                msgerror += "Пароль должен состоять минимум из 4-х символов!\n";
            }
            if (MyPassword.Text.Length > 100)
            {
                error = true;
                msgerror += "Пароль превышает максимальное количество символов (100)!\n";
            }


            if (MyPhone.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите номер телефона!\n";
            }
            else if (MyPhone.Text.Length < 5)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (MyPhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }
            if (MyFace.Text == String.Empty)
            {
                error = true;
                msgerror += "Выберите лицо!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка изменения", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }



    }
}
