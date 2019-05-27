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
    /// Логика взаимодействия для AddStorage.xaml
    /// </summary>
    public partial class AddStorage : Window
    {
        STOModelContext db = new STOModelContext();

        public AddStorage()
        {
            InitializeComponent();
        }

        Storage AddPage;

        public AddStorage(Storage a)
        {
            InitializeComponent();
            AddPage = a;
            ComboboxSupply();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                AddSupplyId.DisplayMemberPath = "SupplyId";

                Model.Storage newStorage = new Model.Storage()
                {
                    NumberProduct = Int32.Parse(AddNumberProduct.Text),
                    SupplyId = Int32.Parse(AddSupplyId.Text)
                };

                int ID = Int32.Parse(AddSupplyId.Text);
                var ParthName = (from parht in db.Supplies
                                 where (parht.SupplyId == ID)
                                 select parht.Product).First();
                string nameproduct = ParthName;
                newStorage.Product = nameproduct;

                var CostParth = (from parht in db.Supplies
                                 where (parht.SupplyId == ID)
                                 select parht.Cost).First();
                Single costproduct = CostParth;
                if (AddCast.Text == String.Empty)
                {
                    costproduct *= (float)1.1;
                }
                else
                {
                    costproduct *= (float)((Double.Parse(AddCast.Text) + 100) / 100);
                }
                newStorage.Cost = costproduct;

                var NumberParth = (from parht in db.Supplies
                                   where (parht.SupplyId == ID)
                                   select parht.Number).First();
                int numberproduct = NumberParth;
                newStorage.Number = numberproduct;
                db.Storages.Add(newStorage);
                db.SaveChanges();
                Storage.a.ItemsSource = db.Storages.ToList();
                this.Hide();
            }
        }


        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            if (AddNumberProduct.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите код товара!\n";
            }
            else if (!AddNumberProduct.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный код!\n";
            }
            else if (Int32.Parse(AddNumberProduct.Text) >= 1000000 || Int32.Parse(AddNumberProduct.Text) <= 100000)
            {
                error = true;
                msgerror += "Код должен быть 6-ти значным!\n";
            }
            if (AddCast.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите цену!\n";
            }
            else if (!AddCast.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная ценовая надбавка!\n";
            }
            else if (Single.Parse(AddCast.Text) >= 1000 || Single.Parse(AddCast.Text) < 0)
            {
                error = true;
                msgerror += "Введена некорректная ценовая надбавка!\n";
            }
            if (AddSupplyId.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите номер поставки!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }


        public void ComboboxSupply()
        {
            AddSupplyId.ItemsSource = db.Supplies.ToList();
        }
    }
}
