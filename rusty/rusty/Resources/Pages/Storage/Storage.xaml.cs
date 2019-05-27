using rusty.Resources.Model;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rusty.Resources.Pages.Storage
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Storage : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Storage()
        {
            InitializeComponent();
            db = new STOModelContext();
            storageGrid.ItemsSource = db.Storages.ToList();
            a = storageGrid;
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
                Cost.Visibility = Visibility.Collapsed;
            }
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddStorage addStorage = new AddStorage(this);
            addStorage.Topmost = true;
            addStorage.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string ProductName;
                int ProductNumber;
                int Number;
                int Id;
                Single Cost;
                if (storageGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < storageGrid.SelectedItems.Count; i++)
                    {
                        Model.Storage storage = storageGrid.SelectedItems[i] as Model.Storage;

                        ProductName = storage.Product;
                        ProductNumber = storage.NumberProduct;
                        Number = storage.Number;
                        Id = storage.SupplyId;
                        Cost = storage.Cost;

                        UpdateStorage update = new UpdateStorage(ProductName, ProductNumber, Number, Id, Cost, this);
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
                int? Id = (storageGrid.SelectedItem as Model.Storage).StorageId;
                var deleteStorage = db.Storages.Where(db => db.StorageId == Id).FirstOrDefault();
                db.Storages.Remove(deleteStorage);
                db.SaveChanges();
                storageGrid.ItemsSource = db.Storages.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }

        private void Minus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (storageGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < storageGrid.SelectedItems.Count; i++)
                    {
                        Model.Storage storage = storageGrid.SelectedItems[i] as Model.Storage;
                        if (storage.Number != 0)
                        {
                            storage.Number -= 1;
                        }

                    }

                }

                db.SaveChanges();
                storageGrid.ItemsSource = db.Storages.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
