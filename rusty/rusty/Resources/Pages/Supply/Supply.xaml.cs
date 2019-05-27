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

namespace rusty.Resources.Pages.Supply
{
    /// <summary>
    /// Логика взаимодействия для Supply.xaml
    /// </summary>
    public partial class Supply : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public Supply()
        {
            InitializeComponent();
            db = new STOModelContext();
            supplyGrid.ItemsSource = db.Supplies.ToList();
            a = supplyGrid;
        }
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddSupply addSupply = new AddSupply(this);
            addSupply.Topmost = true;
            addSupply.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string NameP;
                int Number;
                string NameShipper;
                int Id;
                Single Cost;
                if (supplyGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < supplyGrid.SelectedItems.Count; i++)
                    {
                        Model.Supply supply = supplyGrid.SelectedItems[i] as Model.Supply;

                        NameP = supply.Product;
                        Number = supply.Number;
                        NameShipper = supply.ShipperName;
                        Id = supply.ShipperId;
                        Cost = supply.Cost;

                        UpdateSupply update = new UpdateSupply(NameP, Number, Id, Cost, NameShipper, this);
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
                int? Id = (supplyGrid.SelectedItem as Model.Supply).SupplyId;
                var deleteSupply = db.Supplies.Where(db => db.SupplyId == Id).FirstOrDefault();
                db.Supplies.Remove(deleteSupply);
                db.SaveChanges();
                supplyGrid.ItemsSource = db.Supplies.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
