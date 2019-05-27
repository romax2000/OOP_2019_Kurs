using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace rusty.Resources.Pages.Requests
{
    /// <summary>
    /// Логика взаимодействия для UpdateRequest.xaml
    /// </summary>
    public partial class UpdateRequest : Window
    {
        public UpdateRequest()
        {
            InitializeComponent();
        }

        private void UpdatePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Jpg Files (*.jpg)|*.jpg|Jpeg Files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == true)
            {
                Path.Text = ofd.FileName;
            }
        }

        STOModelContext db = new STOModelContext();
        public int CustomerId;
        public int CarId;
        public string Specification;
        public string Imagie;
        public int StorageId;
        public string Status;
        public string CarName;
        public string StorageName;
        public string CustomerName;
        public string ImagieOn;
        public int ServiceId;
        Requests Request;

        public UpdateRequest(int customer, int car, string specification, string img, int storage, string status, string carn,string storagen,string customern, string imagieOn,int service, Requests request)
        {
            InitializeComponent();
            CustomerId = customer;
            CarId = car;
            Specification = specification;
            Imagie = img;
            StorageId = storage;
            Status = status;
            Request = request;
            CarName = carn;
            StorageName = storagen;
            CustomerName = customern;
            ImagieOn = imagieOn;
            ServiceId = service;
            Combobox();

        }
        public void Combobox()
        {
            UpdateCustomer.ItemsSource = db.Customers.ToList();
            UpdateModel.ItemsSource = db.Cars.ToList();
            UpdateMark.ItemsSource = db.Cars.ToList();
            UpdateStorage.ItemsSource = db.Storages.ToList();
            UpdateRegNummber.ItemsSource = db.Cars.ToList();
            UpdateService.ItemsSource = db.Services.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string namecar = UpdateMark.Text + " " + UpdateModel.Text;
                string namestorage = UpdateStorage.Text;
                string namecustomer = UpdateCustomer.Text;
                UpdateCustomer.DisplayMemberPath = "CustomerId";
                UpdateModel.DisplayMemberPath = "CarId";
                UpdateMark.DisplayMemberPath = "CarId";
                UpdateRegNummber.DisplayMemberPath = "CarId";
                UpdateStorage.DisplayMemberPath = "StorageId";
                UpdateService.DisplayMemberPath = "ServiceId";
                Model.Request UpdateRequest = (from request in db.Requests
                                               where (
                    request.CustomerId == CustomerId &&
                     request.CarId == CarId &&
                      request.Specification == Specification &&
                       request.Imagie == Imagie &&
                        request.StorageId == StorageId &&
                         request.Status == Status &&
                         request.CarName == CarName &&
                         request.StorageName == StorageName &&
                         request.CustomerName == CustomerName &&
                         request.ImagieOn == ImagieOn &&
                         request.ServiceId == ServiceId
                    )
                                               select request).Single();
                if (UpdateCustomer.Text != String.Empty)
                {
                    UpdateRequest.CustomerId = Int32.Parse(UpdateCustomer.Text);
                    UpdateRequest.CustomerName = namecustomer;
                }
                if (UpdateRegNummber.Text != String.Empty && UpdateModel.Text != String.Empty && UpdateMark.Text != String.Empty)
                {
                    UpdateRequest.CarId = Int32.Parse(UpdateRegNummber.Text);
                    UpdateRequest.CarName = namecar;
                }
                if (UpdateSpecification.Text != String.Empty)
                    UpdateRequest.Specification = UpdateSpecification.Text;
                if (Path.Text != String.Empty)
                {
                    UpdateRequest.Imagie = Path.Text;
                    UpdateRequest.ImagieOn = "+";
                }
                if (UpdateStorage.Text != String.Empty)
                {
                    UpdateRequest.StorageId = Int32.Parse(UpdateStorage.Text);
                    UpdateRequest.StorageName = namestorage;
                }
                if (UpdateStatus.Text != String.Empty)
                    UpdateRequest.Status = UpdateStatus.Text;
                if (UpdateService.Text != String.Empty)
                    UpdateRequest.ServiceId = Int32.Parse(UpdateService.Text);
                db.Entry(UpdateRequest).State = EntityState.Modified;
                db.SaveChanges();

                this.Hide();
                db.Requests.Load();
                db.Services.Load();
                Requests.a.ItemsSource = db.Requests.ToList();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (UpdateCustomer.Text != String.Empty && (UpdateRegNummber.Text == String.Empty || UpdateMark.Text == String.Empty || UpdateModel.Text == String.Empty))
            {
                error = true;
                msgerror += "При изменении клиента автомобиль должен быть указан заново!\n";
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
