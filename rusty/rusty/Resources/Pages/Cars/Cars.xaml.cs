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

namespace rusty.Resources.Pages.Cars
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        STOModelContext db;
        public static DataGrid a;
        public MainWindow mainWindow;
        public Cars()
        {
            InitializeComponent();
            db = new STOModelContext();
            carGrid.ItemsSource = db.Cars.ToList();
            a = carGrid;
            if (MainWindow.current_user == "user")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                CarId.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.current_user == "master")
            {
                Update.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                
            }
        }
        
        private void Add_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCar addCar = new AddCar(this);
            addCar.Topmost = true;
            addCar.Show();
        }
        private void Update_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            string Model;
            string Mark;
            string Body;
            int Year;
            string Color;
            string Engine;
            string Number;

            if (carGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < carGrid.SelectedItems.Count; i++)
                {
                    Model.Car car = carGrid.SelectedItems[i] as Model.Car;

                    Model = car.CarModel;
                    Mark = car.CarMark;
                    Year = car.Year;
                    Color = car.Color;
                    Body = car.Body;
                    Number = car.RegNummber;
                    Engine = car.Engine;
                    UpdateCar update = new UpdateCar(Model,Mark,Year,Body,Color,Number,Engine,this);
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
                int? Id = (carGrid.SelectedItem as Model.Car).CarId;
                var deleteCar = db.Cars.Where(db => db.CarId == Id).FirstOrDefault();
                db.Cars.Remove(deleteCar);
                db.SaveChanges();
                carGrid.ItemsSource = db.Cars.ToList();
            }
            catch (NullReferenceException)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка удаления", "Запись является пустой", MessageBoxButton.OK);
            }
        }
    }
}
