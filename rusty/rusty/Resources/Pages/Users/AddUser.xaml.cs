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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
       
            STOModelContext db = new STOModelContext();

            public AddUser()
            {
                InitializeComponent();
            }

            Users AddPage;

            public AddUser(Users a)
            {
                InitializeComponent();
                AddPage = a;
            }

            private void Add_Click(object sender, RoutedEventArgs e)
            {
            if (ValidateForm())
            {
                Model.User newUser = new Model.User()
                {
                    Lonin = AddLogin.Text,
                    Password = AddPassword.Text,
                    UserType = AddType.Text
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                Users.a.ItemsSource = db.Users.ToList();
                this.Hide();
            }
       }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            if (AddLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(AddLogin.Text)).FirstOrDefault();
                if (user != null)

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
            if (AddPassword.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите пароль!\n";
            }
            else if (AddPassword.Text.Length < 4)
            {
                error = true;
                msgerror += "Пароль должен состоять минимум из 4-х символов!\n";
            }
            if (AddPassword.Text.Length > 100)
            {
                error = true;
                msgerror += "Пароль превышает максимальное количество символов (100)!\n";
            }
            if (AddType.Text == String.Empty)
            {
                error = true;
                msgerror += "Выберите тип пользователя!\n";
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
