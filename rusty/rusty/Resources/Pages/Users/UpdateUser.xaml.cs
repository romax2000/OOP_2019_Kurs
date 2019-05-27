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

namespace rusty.Resources.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        STOModelContext db = new STOModelContext();
        public string Login;
        public string Password;
        public string Type;
        Users User;
        public UpdateUser()
        {
            InitializeComponent();
        }

        public UpdateUser(string log, string pass, string type, Users user)
        {
            InitializeComponent();
            Login = log;
            Password = pass;
            Type = type;
            User = user;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.User UpdateUser = (from users in db.Users
                                         where (
              users.Lonin == Login &&
              users.Password == Password &&
              users.UserType == Type
                            )
                                         select users).Single();
                if (UpdateLogin.Text != String.Empty)
                {
                    UpdateUser.Lonin = UpdateLogin.Text;
                    MainWindow.current_login = UpdateLogin.Text;
                }
                if (UpdatePassword.Text != String.Empty)
                    UpdateUser.Password = UpdatePassword.Text;
                if (UpdateType.Text != String.Empty)
                    UpdateUser.UserType = UpdateType.Text;
                db.SaveChanges();
                Users.a.ItemsSource = db.Users.ToList();
                this.Hide();
            }

        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (UpdateLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(UpdateLogin.Text)).FirstOrDefault();
                if (user != null)

                {
                    error = true;
                    msgerror += "Такой логин уже существует!\n";
                }
            }

            if (UpdateLogin.Text.Length < 4 && UpdateLogin.Text !=String.Empty)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }
            if (UpdateLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }
           
            if (UpdatePassword.Text.Length < 4 && UpdatePassword.Text != String.Empty)
            {
                error = true;
                msgerror += "Пароль должен состоять минимум из 4-х символов!\n";
            }
            if (UpdatePassword.Text.Length > 100)
            {
                error = true;
                msgerror += "Пароль превышает максимальное количество символов (100)!\n";
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
