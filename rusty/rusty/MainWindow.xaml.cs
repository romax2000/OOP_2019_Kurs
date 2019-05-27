using rusty.Resources.Model;
using rusty.Resources.Pages.Cars;
using rusty.Resources.Pages.Customers;
using rusty.Resources.Pages.Users;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rusty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        STOModelContext db;
        GranWin gr = new GranWin();
        static public string current_user;
        static public string current_login;
        public MainWindow()
        {
            InitializeComponent();
            db = new STOModelContext();
           
        }

        int k = 0;

        private void ButtonSingUP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (k == 0)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 300;
                animation.To = 550;
                animation.Duration = TimeSpan.FromSeconds(1);
                WindowAuth.BeginAnimation(Rectangle.HeightProperty, animation);
                k++;
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 550;
                animation.To = 300;
                animation.Duration = TimeSpan.FromSeconds(1);
                WindowAuth.BeginAnimation(Rectangle.HeightProperty, animation);
                k--;
            }
        }

        private void SIGN_IN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var InfoPassword = User.getHash(PasswordBox.Password);
                var user = db.Users.Where(d => (d.Lonin).Equals(LoginBox.Text) && d.Password.Equals(PasswordBox.Password)).FirstOrDefault();
                if (user != null)
                {
                    current_user = user.UserType;
                    current_login = user.Lonin;
                    if (user.UserType == "admin") {
                        gr.Show();
                        this.Hide();
                    }
                    if (user.UserType == "user")
                    {
                       
                        gr.Storage.Visibility = Visibility.Collapsed;
                       
                        gr.Customers.Visibility = Visibility.Collapsed;
                        gr.Shippers.Visibility = Visibility.Collapsed;
                        gr.Supply.Visibility = Visibility.Collapsed;
                        gr.Users.Visibility = Visibility.Collapsed;
                        gr.Workplaces.Visibility = Visibility.Collapsed;
                        gr.Show();
                        
                        this.Hide();
                    }
                    if (user.UserType == "master")
                    {
                        gr.Shippers.Visibility = Visibility.Collapsed;
                        gr.Supply.Visibility = Visibility.Collapsed;
                        gr.Users.Visibility = Visibility.Collapsed;
                        gr.Show();
                        this.Hide();
                    }
                }
                else
                {
                 
                    rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка авторизации!","Введён неверный логин или пароль", MessageBoxButton.OK);
                    PasswordBox.Password = String.Empty;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SIGN_UP_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                User newUser = new User();
                newUser.Lonin = NewLoginBox.Text;
                //newUser.Password = User.getHash(NewPasswordBox.Password);
                newUser.Password = NewPasswordBox.Password;
                newUser.UserType = "user";
                db.Users.Add(newUser);
                db.SaveChanges();
                AddCustomer addCustomer = new AddCustomer();
                addCustomer.AddLogin.Text = newUser.Lonin;
                addCustomer.Show();
                NewLoginBox.Text = String.Empty;
                NewPasswordBox.Password = String.Empty;
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            if (NewLoginBox.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(NewLoginBox.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(NewLoginBox.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(NewLoginBox.Text)).FirstOrDefault();
                if (user != null  || master != null || customer != null)
                {
                    error = true;
                    msgerror += "Такой пользователь уже существует!\n";
                }
            }

            if (NewLoginBox.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите логин!\n";
            }
            else if (NewLoginBox.Text.Length < 4)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }
            
            if (NewLoginBox.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }
            if (NewPasswordBox.Password == String.Empty)
            {
                error = true;
                msgerror += "Введите пароль!\n";
            }
            else if (NewPasswordBox.Password.Length < 4)
            {
                error = true;
                msgerror += "Пароль должен состоять минимум из 4-х символов!\n";
            }
            if (NewPasswordBox.Password.Length > 100)
            {
                error = true;
                msgerror += "Пароль превышает максимальное количество символов (100)!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка регистрации", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        private void Close_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }
    }
}
