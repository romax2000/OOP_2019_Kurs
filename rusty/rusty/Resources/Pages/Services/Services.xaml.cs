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

namespace rusty.Resources.Pages.Services
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
       
            STOModelContext db;
            public static DataGrid a;
            public Services()
            {
                InitializeComponent();
                db = new STOModelContext();
                serviceGrid.ItemsSource = db.Services.ToList();
                a = serviceGrid;
            if (MainWindow.current_user == "user")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
            }
    }
            private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                AddService addService = new AddService(this);
            addService.Topmost = true;
            addService.Show();
            }
            private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
            try { 
                string Name;
                Single Cost;

                if (serviceGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < serviceGrid.SelectedItems.Count; i++)
                    {
                        Model.Service service = serviceGrid.SelectedItems[i] as Model.Service;
                        Name = service.ServiceName;
                        Cost = service.Cost;
                        UpdateService update = new UpdateService(Name, Cost, this);
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
                int? Id = (serviceGrid.SelectedItem as Model.Service).ServiceId;
                var deleteService = db.Services.Where(db => db.ServiceId == Id).FirstOrDefault();
                db.Services.Remove(deleteService);
                db.SaveChanges();
                serviceGrid.ItemsSource = db.Services.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
