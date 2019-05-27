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

namespace rusty.Resources.Pages.Shippers
{
    /// <summary>
    /// Логика взаимодействия для Shippers.xaml
    /// </summary>
    public partial class Shippers : Page

    {
        STOModelContext db;
        public static DataGrid a;
        public Shippers()
        {
            InitializeComponent();
            db = new STOModelContext();
            shipperGrid.ItemsSource = db.Shippers.ToList();
            a = shipperGrid;
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddShipper addShipper = new AddShipper(this);
            addShipper.Topmost = true;
            addShipper.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            string Name;
            string Address;
            string Phone;
            if (shipperGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < shipperGrid.SelectedItems.Count; i++)
                {
                    Model.Shipper shipper = shipperGrid.SelectedItems[i] as Model.Shipper;

                    Name = shipper.CompanyName;
                    Address = shipper.Address;
                    Phone = shipper.PhoneNumber;
                   
                    UpdateShipper update = new UpdateShipper(Name, Address, Phone, this);
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
                int? Id = (shipperGrid.SelectedItem as Model.Shipper).ShipperId;
                var deleteShipper = db.Shippers.Where(db => db.ShipperId == Id).FirstOrDefault();
                db.Shippers.Remove(deleteShipper);
                db.SaveChanges();
                shipperGrid.ItemsSource = db.Shippers.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
