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

namespace rusty.Resources.Pages.Storage
{
    /// <summary>
    /// Логика взаимодействия для UpdateStorage.xaml
    /// </summary>
    public partial class UpdateStorage : Window
    {
        STOModelContext db = new STOModelContext();
        public string ProductName;
        public int ProductNumber;
        public int Number;
        public int SupplyId;
        public Single Cost;
        Storage Storage;
        public UpdateStorage()
        {
            InitializeComponent();
        }

        public UpdateStorage(string name, int prodnumber, int number, int ID, Single cost, Storage storage)
        {
            InitializeComponent();
            ProductName = name;
            ProductNumber = prodnumber;
            Number = number;
            SupplyId = ID;
            Cost = cost;
            Storage = storage;
            ComboboxSupply();

        }
        public void ComboboxSupply()
        {
            UpdateSupplyId.ItemsSource = db.Supplies.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                UpdateSupplyId.DisplayMemberPath = "SupplyId";
                Model.Storage UpdateStorage = (from storage in db.Storages
                                               where (
                    storage.Product == ProductName &&
                    storage.NumberProduct == ProductNumber &&
                    storage.Number == Number &&
                    storage.SupplyId == SupplyId &&
                    storage.Cost == Cost
                    )
                                               select storage).Single();
                if (UpdateSupplyId.Text != String.Empty)
                {
                    //UpdateStorage.Product = UpdateProductName.Text;
                    int ID = Int32.Parse(UpdateSupplyId.Text);
                    var ParthName = (from parht in db.Supplies
                                     where (parht.SupplyId == ID)
                                     select parht.Product).First();
                    string nameproduct = ParthName;
                    UpdateStorage.Product = nameproduct;
                }
                if (UpdateNumberProduct.Text != String.Empty)
                    UpdateStorage.NumberProduct = Int32.Parse(UpdateNumberProduct.Text);
                if (UpdateNumber.Text != String.Empty)
                    UpdateStorage.Number = Int32.Parse(UpdateNumber.Text);
                if (UpdateSupplyId.Text != String.Empty)
                    UpdateStorage.SupplyId = Int32.Parse(UpdateSupplyId.Text);
                if (UpdateCost.Text != String.Empty)
                {
                    UpdateStorage.Cost = Single.Parse(UpdateCost.Text);
                    int ID = Int32.Parse(UpdateSupplyId.Text);

                    var CostParth = (from parht in db.Supplies
                                     where (parht.SupplyId == ID)
                                     select parht.Cost).First();
                    Single costproduct = CostParth;
                    costproduct *= (float)((Double.Parse(UpdateCost.Text) + 100) / 100);
                    UpdateStorage.Cost = costproduct;
                }
                db.SaveChanges();
                Storage.a.ItemsSource = db.Storages.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (!UpdateNumberProduct.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный код!\n";
            }
            else if (UpdateNumberProduct.Text != String.Empty)
            {
                if (Int32.Parse(UpdateNumberProduct.Text) >= 1000000 || Int32.Parse(UpdateNumberProduct.Text) <= 100000)
                {
                    error = true;
                    msgerror += "Код должен быть 6-ти значным!\n";
                }
            }

            if (!UpdateCost.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная ценовая надбавка!\n";
            }
            else if (UpdateCost.Text != String.Empty)
            {
                if (Single.Parse(UpdateCost.Text) >= 1000 || Single.Parse(UpdateCost.Text) < 0)
                {
                    error = true;
                    msgerror += "Введена некорректная ценовая надбавка!\n";
                }
            }

            if (!UpdateNumber.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введено некорректное количество!\n";
            }
            else if (UpdateNumber.Text != String.Empty)
            {
                if (Single.Parse(UpdateNumber.Text) >= 100000 || Single.Parse(UpdateNumber.Text) < 0)
                {
                    error = true;
                    msgerror += "Введено некорректное количество!\n";
                }
            }

            if (UpdateSupplyId.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите номер поставки!\n";
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
