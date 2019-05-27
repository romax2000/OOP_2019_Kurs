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
    /// Логика взаимодействия для UpdateShipper.xaml
    /// </summary>
    public partial class UpdateShipper : Window
    {
        STOModelContext db = new STOModelContext();
        public string Name;
        public string Address;
        public string Phone;
        Shippers Shipper;
        public UpdateShipper()
        {
            InitializeComponent();
        }

        public UpdateShipper(string name, string address, string phone, Shippers shipper)
        {
            InitializeComponent();
            Name = name;
            Address = address;
            Phone = phone;
            Shipper = shipper;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Shipper UpdateShipper = (from shipper in db.Shippers
                                               where (
                    shipper.CompanyName == Name &&
                    shipper.Address == Address &&
                    shipper.PhoneNumber == Phone
                                 )
                                               select shipper).Single();
                if (UpdateName.Text != String.Empty)
                    UpdateShipper.CompanyName = UpdateName.Text;
                if (UpdateAddress.Text != String.Empty)
                    UpdateShipper.Address = UpdateAddress.Text;
                if (UpdatePhone.Text != String.Empty)
                    UpdateShipper.PhoneNumber = UpdatePhone.Text;
                db.SaveChanges();
                Shippers.a.ItemsSource = db.Shippers.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
           
            if (UpdateName.Text.Length < 3 && UpdateName.Text != String.Empty)
            {
                error = true;
                msgerror += "Название должно состоять минимум из 3-х символов!\n";
            }
            if (UpdateName.Text.Length > 200)
            {
                error = true;
                msgerror += "Название превышает максимальное количество символов (200)!\n";
            }

           
            if (UpdateAddress.Text.Length < 3 && UpdateAddress.Text != String.Empty)
            {
                error = true;
                msgerror += "Адрес должен состоять минимум из 3-х символов!\n";
            }
            if (UpdateAddress.Text.Length > 200)
            {
                error = true;
                msgerror += "Адрес превышает максимальное количество символов (200)!\n";
            }

          
            if (UpdatePhone.Text.Length < 5 && UpdatePhone.Text != String.Empty)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (UpdatePhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
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