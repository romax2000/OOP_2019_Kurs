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

namespace rusty.Resources.Pages.Shippers
{
    /// <summary>
    /// Логика взаимодействия для AddShipper.xaml
    /// </summary>
    public partial class AddShipper : Window
    {
        STOModelContext db = new STOModelContext();

        public AddShipper()
        {
            InitializeComponent();
        }

        Shippers AddPage;

        public AddShipper(Shippers a)
        {
            InitializeComponent();
            AddPage = a;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Shipper newShipper = new Model.Shipper()
                {
                    CompanyName = AddName.Text,
                    Address = AddAddress.Text,
                    PhoneNumber = AddPhone.Text
                };

                db.Shippers.Add(newShipper);
                db.SaveChanges();
                Shippers.a.ItemsSource = db.Shippers.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            
            if (AddName.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите название компании!\n";
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

            //if (AddAddress.Text == String.Empty)
            //{
            //    error = true;
            //    msgerror += "Введите адрес!\n";
            //}
            //else if (AddAddress.Text.Length < 3)
            //{
            //    error = true;
            //    msgerror += "Адрес должен состоять минимум из 3-х символов!\n";
            //}
            //if (AddAddress.Text.Length > 200)
            //{
            //    error = true;
            //    msgerror += "Адрес превышает максимальное количество символов (200)!\n";
            //}

            if (AddPhone.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите номер телефона!\n";
            }
            else if (AddPhone.Text.Length < 5)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (AddPhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}
