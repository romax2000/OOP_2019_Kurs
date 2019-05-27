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

namespace rusty.Resources.Pages.Supply
{
    /// <summary>
    /// Логика взаимодействия для UpdateSupply.xaml
    /// </summary>
    public partial class UpdateSupply : Window
    {
        STOModelContext db = new STOModelContext();
        public string NameP;
        public int Number;
        public string NameShipper;
        public int ShipperID;
        public Single Cost;
        Supply Supply;
        public UpdateSupply()
        {
            InitializeComponent();
        }
       
        public UpdateSupply(string name, int number, int shID, Single cost, string nameSh, Supply supply)
        {
            InitializeComponent();
            NameP = name;
            Number = number;
           NameShipper = nameSh;
            ShipperID = shID;
            Cost = cost;
            Supply = supply;
            ComboboxShipper();

        }
        public void ComboboxShipper()
        {
            UpdateShipper.ItemsSource = db.Shippers.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string name = UpdateShipper.Text;
                UpdateShipper.DisplayMemberPath = "ShipperId";
                Model.Supply UpdateSupply = (from supply in db.Supplies
                                             where (
                  supply.Product == NameP &&
                  supply.Number == Number &&
                 supply.ShipperName == NameShipper &&
                  supply.ShipperId == ShipperID &&
                  supply.Cost == Cost
                  )
                                             select supply).Single();
                if (UpdateName.Text != String.Empty)
                    UpdateSupply.Product = UpdateName.Text;
                if (UpdateNumber.Text != String.Empty)
                    UpdateSupply.Number = Int32.Parse(UpdateNumber.Text);
                if (UpdateShipper.Text != String.Empty)
                {
                    UpdateSupply.ShipperId = Int32.Parse(UpdateShipper.Text);
                    UpdateSupply.ShipperName = name;
                }
                if (UpdateCast.Text != String.Empty)
                    UpdateSupply.Cost = Single.Parse(UpdateCast.Text);
                db.SaveChanges();
                Supply.a.ItemsSource = db.Supplies.ToList();
                this.Hide();
            }

        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (!UpdateNumber.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введено некорректное колличество!\n";
            }
            else if (UpdateNumber.Text != String.Empty)
            { 
            if (Int32.Parse(UpdateNumber.Text) >= 100000 || Int32.Parse(UpdateNumber.Text) <= 0)
                {
                    error = true;
                    msgerror += "Введено некорректное колличество!\n";
                }
            }
          
            if (UpdateName.Text.Length < 3 && UpdateName.Text !=String.Empty)
            {
                error = true;
                msgerror += "Название должно состоять минимум из 3-х символов!\n";
            }
            if (UpdateName.Text.Length > 200)
            {
                error = true;
                msgerror += "Название превышает максимальное количество символов (200)!\n";
            }

            if (!UpdateCast.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
            else if (UpdateCast.Text != String.Empty)
            {
                if (Single.Parse(UpdateCast.Text) >= 100000 || Single.Parse(UpdateCast.Text) <= 0)
                {
                    error = true;
                    msgerror += "Введена некорректная цена!\n";
                }
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
