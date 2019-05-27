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

namespace rusty.Resources.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Users()
        {
            InitializeComponent();
            db = new STOModelContext();
            userGrid.ItemsSource = db.Users.ToList();
            a = userGrid;
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddUser addUser = new AddUser(this);
            addUser.Topmost = true;
            addUser.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string Login;
                string Password;
                string Type;

                if (userGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < userGrid.SelectedItems.Count; i++)
                    {
                        Model.User user = userGrid.SelectedItems[i] as Model.User;

                        Login = user.Lonin;
                        Password = user.Password;
                        Type = user.UserType;
                        UpdateUser update = new UpdateUser(Login, Password, Type, this);
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
                int? Id = (userGrid.SelectedItem as Model.User).Id;
                var deleteUser = db.Users.Where(db => db.Id == Id).FirstOrDefault();
                db.Users.Remove(deleteUser);
                db.SaveChanges();
                userGrid.ItemsSource = db.Users.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
