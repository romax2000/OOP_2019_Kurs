using Microsoft.Win32;
using rusty.Resources.Model;
using rusty.Resources.Pages.Cars;
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

namespace rusty.Resources.Pages.Requests
{
    /// <summary>
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Window
    {
        

        private void AddPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Jpg Files (*.jpg)|*.jpg|Jpeg Files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == true)
            {
                Path.Text = ofd.FileName;
            }
        }
        STOModelContext db = new STOModelContext();

        public AddRequest()
        {
            InitializeComponent();
        }

        Requests AddPage;

        public AddRequest(Requests a)
        {
            InitializeComponent();
            AddPage = a;
            Combobox();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string nameCustomer = AddCustomer.Text;
                string nameStorage = AddStorage.Text;
                string nameCar = AddMark.Text + " " + AddModel.Text;
                AddCustomer.DisplayMemberPath = "CustomerId";
                AddMark.DisplayMemberPath = "CarId";
                AddModel.DisplayMemberPath = "CarId";
                AddStorage.DisplayMemberPath = "StorageId";
                AddRegNummber.DisplayMemberPath = "CarId";
                AddService.DisplayMemberPath = "ServiceId";
                Model.Request newRequest = new Model.Request()
                {
                    CustomerId = Int32.Parse(AddCustomer.Text),
                    CarId = Int32.Parse(AddRegNummber.Text),
                    Specification = AddSpecification.Text,
                    Imagie = Path.Text,
                    StorageId = Int32.Parse(AddStorage.Text),
                    ServiceId = Int32.Parse(AddService.Text),
                    Status = "Ожидает рассмотрения",
                    CarName = nameCar,
                    StorageName = nameStorage,
                    CustomerName = nameCustomer

                };
                if (Path.Text != String.Empty)
                {
                    newRequest.ImagieOn = "+";
                }
                else
                {
                    newRequest.ImagieOn = "-";
                }
                db.Requests.Add(newRequest);
                db.SaveChanges();
                Requests.a.ItemsSource = db.Requests.ToList();
                this.Hide();
            }
        }


        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
           
            if (AddCustomer.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите клиента!\n";
            }

            if (AddMark.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите марку авто!\n";
            }

            if (AddModel.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите модель авто!\n";
            }

            if (AddRegNummber.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите регистрационный номер авто!\n";
            }

            if (AddSpecification.Text == String.Empty)
            {
                error = true;
                msgerror += "Опишите проблему!\n";
            }
            if (AddSpecification.Text.Length > 200)
            {
                error = true;
                msgerror += "Описание превышает максимальное количество символов (200)!\n";
            }
            if (AddStorage.Text == String.Empty && AddService.Text == String.Empty)
            {
                error = true;
                msgerror += "Укажите деталь на замену или(и) услугу!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        public void Combobox()
        {
            AddCustomer.ItemsSource = db.Customers.ToList();
            AddMark.ItemsSource = db.Cars.ToList();
            AddModel.ItemsSource = db.Cars.ToList();
            AddStorage.ItemsSource = db.Storages.ToList();
            AddRegNummber.ItemsSource = db.Cars.ToList();
            AddService.ItemsSource = db.Services.ToList();
        }

    }
}
