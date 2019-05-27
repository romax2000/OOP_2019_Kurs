using rusty.Resources.Model;
using rusty.Resources.Pages.Cars;
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

namespace rusty.Resources.Pages.Requests
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Requests : Page
    {
            STOModelContext db;
            public static DataGrid a;
            public Requests()
            {
                InitializeComponent();
                db = new STOModelContext();
                db.Services.Load();
                db.Requests.Load();
                requestGrid.ItemsSource = db.Requests.ToList();
                a = requestGrid;
            if (MainWindow.current_user == "user")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                RequestId.Visibility = Visibility.Collapsed;
                CustomerId.Visibility = Visibility.Collapsed;
                CarId.Visibility = Visibility.Collapsed;
                StorageId.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                Add.Visibility = Visibility.Collapsed;
            }
        }
            private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                AddRequest addRequest = new AddRequest(this);
            addRequest.Topmost = true;
            addRequest.Show();
            }

        //public void CheckedPhoto()
        //{
        //    var quary = db.Requests.Where(r => r.Imagie != String.Empty).Single();
        //    if(quary != null)
        //    {
        //        CheckedImage.Text
        //    }
        //}
            private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
            try { 
            int CustomerId;
            int CarId;
            string Specification;
            string Imagie;
            int StorageId;
            string Status;
            string CarName;
            int ServiceId;
            string StorageName;
            string CustomerName;
            string ImagieOn;
                if (requestGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < requestGrid.SelectedItems.Count; i++)
                    {
                        Model.Request request = requestGrid.SelectedItems[i] as Model.Request;
                    CustomerId = request.CustomerId;
                    CarId = request.CarId;
                    Specification = request.Specification;
                    Imagie = request.Imagie;
                    StorageId = request.StorageId;
                    Status = request.Status;
                    ServiceId = request.ServiceId;
                    CarName = request.CarName;
                    StorageName = request.StorageName;
                    CustomerName = request.CustomerName;
                    ImagieOn = request.ImagieOn;
                        UpdateRequest update = new UpdateRequest(CustomerId,CarId,Specification,Imagie,StorageId,Status,CarName,StorageName,CustomerName,ImagieOn,ServiceId,this);
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
                int? Id = (requestGrid.SelectedItem as Model.Request).RequestId;
                var deleteRequest = db.Requests.Where(db => db.RequestId == Id).FirstOrDefault();
                db.Requests.Remove(deleteRequest);
                db.SaveChanges();
                requestGrid.ItemsSource = db.Requests.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }

        public void Viev_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string img = (requestGrid.SelectedItem as Model.Request).Imagie;
                if (img != null)
                {
                    string path = img;
                    RequestImagie imagie = new RequestImagie();

                    imagie.Imagie.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                    imagie.Show();
                }
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка просмотра", "Запись является пустой", MessageBoxButton.OK);
            }
        }

        private void AddCar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }
    }
}
