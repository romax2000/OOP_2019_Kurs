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
    /// Логика взаимодействия для OfficeAdmin.xaml
    /// </summary>
    public partial class OfficeAdmin : Page
    {
        STOModelContext db = new STOModelContext();
        string MyLog = MainWindow.current_login;
        string Password;
        public OfficeAdmin()
        {
            InitializeComponent();

            Password = (from masters in db.Users
                        where (masters.Lonin == MyLog)
                        select masters.Password).First();
          
            MyLogin.Text = MyLog;
            MyPassword.Text = Password;
        }

        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ValidateForm())
            {
                string MLogin = MyLog;
                string MPassword = Password;

                Model.User UpdateUser = (from admin in db.Users
                                         where (
                                         admin.Lonin == MyLog &&
                                         admin.Password == Password
                                         )
                                         select admin).Single();
                //if (MyLog != MyLogin.Text || Password != MyPassword.Text)

                UpdateUser.Lonin = MyLogin.Text;
                UpdateUser.Password = MyPassword.Text;
                MyLog = MyLogin.Text;
                Password = MyPassword.Text;
                MainWindow.current_login = MyLogin.Text;
                db.SaveChanges();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;


        
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

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка изменения", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}
