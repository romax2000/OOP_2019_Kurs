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

namespace rusty.Resources.Pages.Masters
{
    /// <summary>
    /// Логика взаимодействия для Masters.xaml
    /// </summary>
    public partial class Masters : Page
    {
            STOModelContext db;
            public static DataGrid a;
            public Masters()
            {
                InitializeComponent();
                db = new STOModelContext();
                masterGrid.ItemsSource = db.Masters.ToList();
                a = masterGrid;
            if (MainWindow.current_user == "user")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                MasterID.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Collapsed;
                Exp.Visibility = Visibility.Collapsed;
                WorkplaseId.Visibility = Visibility.Collapsed;
                Salary.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Collapsed;
                Salary.Visibility = Visibility.Collapsed;
            }
        }
            private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                AddMaster addMaster = new AddMaster(this);
            addMaster.Topmost = true;
            addMaster.Show();
            }
            private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
            try { 
                string Login;
                string FIO;
                string Spec;
                int Exp;
                string Phone;
                int WorkplaceId;
             string WorkplaceName;
        Single Salary;
                if (masterGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < masterGrid.SelectedItems.Count; i++)
                    {
                        Model.Master master = masterGrid.SelectedItems[i] as Model.Master;

                    Login = master.Login;
                    FIO = master.FIO;
                    Spec = master.Spec;
                    Exp = master.Exp;
                    Phone = master.Phone;
                    WorkplaceId = master.WorkplaceId;
                    Salary = master.Salary;
                    WorkplaceName = master.WorkplaseName;
                      UpdateMaster update = new UpdateMaster(Login, FIO, Spec, Exp, Phone, WorkplaceId, Salary, WorkplaceName, this);
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
                int? Id = (masterGrid.SelectedItem as Model.Master).MasterId;
                var deleteMaster = db.Masters.Where(db => db.MasterId == Id).FirstOrDefault();
                db.Masters.Remove(deleteMaster);
                db.SaveChanges();
                masterGrid.ItemsSource = db.Masters.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
