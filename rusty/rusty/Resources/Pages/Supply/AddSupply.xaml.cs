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
    /// Логика взаимодействия для AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Window
    {
        STOModelContext db = new STOModelContext();

        public AddSupply()
        {
            InitializeComponent();
        }

        Supply AddPage;
        public string name;
        
        public AddSupply(Supply a)
        {
            InitializeComponent();
            AddPage = a;
            ComboboxShipper();

        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string name = AddShipper.Text;
                AddShipper.DisplayMemberPath = "ShipperId";
                Model.Supply newSupply = new Model.Supply()
                {
                    Number = Int32.Parse(AddNumber.Text),
                    Product = AddName.Text,
                    Cost = Single.Parse(AddCast.Text),
                    DateOrder = DateTime.Now,
                    ShipperId = Int32.Parse(AddShipper.Text),
                    ShipperName = name
                };

                db.Supplies.Add(newSupply);
                db.SaveChanges();
                Supply.a.ItemsSource = db.Supplies.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            if (AddNumber.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите колличество товара!\n";
            }
            else if (!AddNumber.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введено некорректное колличество!\n";
            }
            else if (Int32.Parse(AddNumber.Text) >= 100000 || Int32.Parse(AddNumber.Text) <= 0)
            {
                error = true;
                msgerror += "Введено некорректное колличество!\n";
            }
            if (AddName.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите название товара!\n";
            }
            else if (AddName.Text.Length < 3)
            {
                error = true;
                msgerror += "Название должно состоять минимум из 3-х символов!\n";
            }
            if (AddName.Text.Length > 200)
            {
                error = true;
                msgerror += "Название превышает максимальное количество символов (200)!\n";
            }
            if (AddCast.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите цену!\n";
            }
            else if (!AddCast.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
            else if (Single.Parse(AddCast.Text) >= 100000 || Single.Parse(AddCast.Text) <=0)
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
            if (AddShipper.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите поставщика!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        public void ComboboxShipper()
        {
            AddShipper.ItemsSource = db.Shippers.ToList();
        }
    }
}
