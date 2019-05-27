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

namespace rusty.Resources.Pages.Workplaces
{
    /// <summary>
    /// Логика взаимодействия для Workplaces.xaml
    /// </summary>
    public partial class Workplaces : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Workplaces()
        {
            InitializeComponent();
            db = new STOModelContext();
            workplaceGrid.ItemsSource = db.Workplaces.ToList();
            a = workplaceGrid;
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
            }
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddWorkplace addWorkplace = new AddWorkplace(this);
            addWorkplace.Topmost = true;
            addWorkplace.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string Name;
                string Specification;

                if (workplaceGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < workplaceGrid.SelectedItems.Count; i++)
                    {
                        Model.Workplace workplace = workplaceGrid.SelectedItems[i] as Model.Workplace;
                        Name = workplace.WorkplaceName;
                        Specification = workplace.Specification;
                        UpdateWorkplace update = new UpdateWorkplace(Name, Specification, this);
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
                int? Id = (workplaceGrid.SelectedItem as Model.Workplace).WorkplaceId;
                var deleteWorkplace = db.Workplaces.Where(db => db.WorkplaceId == Id).FirstOrDefault();
                db.Workplaces.Remove(deleteWorkplace);
                db.SaveChanges();
                workplaceGrid.ItemsSource = db.Workplaces.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }

    }
}
