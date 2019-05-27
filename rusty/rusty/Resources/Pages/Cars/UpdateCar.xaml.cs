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

namespace rusty.Resources.Pages.Cars
{
    /// <summary>
    /// Логика взаимодействия для UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar : Window
    {
        STOModelContext db = new STOModelContext();
        public string Model;
        public string Mark;
        public int Year;
        public string Body;
        public string Color;
        public string Number;
        public string Engine;
        Cars Car;
        public UpdateCar()
        {
            InitializeComponent();
        }

        public UpdateCar(string model, string mark, int year, string body, string color, string number, string engine, Cars car)
        {
            InitializeComponent();
            Model = model;
            Mark = mark;
            Year = year;
            Body = body;
            Color = color;
            Number = number;
            Engine = engine;
            Car = car;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Car UpdateCar = (from car in db.Cars
                                       where (
            car.CarModel == Model &&
            car.CarMark == Mark &&
            car.Year == Year &&
            car.Body == Body &&
            car.Color == Color &&
            car.Engine == Engine &&
            car.RegNummber == Number
            )
                                       select car).Single();
                if (UpdateModel.Text != String.Empty)
                    UpdateCar.CarModel = UpdateModel.Text;
                if (UpdateMark.Text != String.Empty)
                    UpdateCar.CarMark = UpdateMark.Text;
                if (UpdateYear.Text != String.Empty)
                    UpdateCar.Year = Int32.Parse(UpdateYear.Text);
                if (UpdateBody.Text != String.Empty)
                    UpdateCar.Body = UpdateBody.Text;
                if (UpdateColor.Text != String.Empty)
                    UpdateCar.Color = UpdateColor.Text;
                if (UpdateEngine.Text != String.Empty)
                    UpdateCar.Engine = UpdateEngine.Text;
                if (UpdateRegNummber.Text != String.Empty)
                    UpdateCar.RegNummber = UpdateRegNummber.Text;
                db.SaveChanges();
                Cars.a.ItemsSource = db.Cars.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (UpdateMark.Text.Length < 3 && UpdateMark.Text != String.Empty)
            {
                error = true;
                msgerror += "Марка указана не верно!\n";
            }
            if (UpdateMark.Text.Length > 100)
            {
                error = true;
                msgerror += "Марка превышает максимальное количество символов(100)!\n";
            }


            if (UpdateModel.Text.Length < 3 && UpdateModel.Text != String.Empty)
            {
                error = true;
                msgerror += "Модель указана не верно!\n";
            }
            if (UpdateModel.Text.Length > 100)
            {
                error = true;
                msgerror += "Модель превышает максимальное количество символов(100)!\n";
            }



            if (UpdateRegNummber.Text.Length < 3 && UpdateRegNummber.Text != String.Empty)
            {
                error = true;
                msgerror += "Регистрационный номер указан не верно!\n";
            }
            if (UpdateRegNummber.Text.Length > 20)
            {
                error = true;
                msgerror += "Регистрационный номер превышает максимальное количество символов(20)!\n";
            }


            if (!UpdateYear.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный год!\n";
            }
            else if (UpdateYear.Text != String.Empty)
            {
                if (Single.Parse(UpdateYear.Text) >= 3000 || Single.Parse(UpdateYear.Text) < 1800)
                {
                    error = true;
                    msgerror += "Введен некорректный год!\n";
                }
            }

           
            else if (UpdateEngine.Text.Length < 2 && UpdateEngine.Text != String.Empty)
            {
                error = true;
                msgerror += "Двигатель введён не верно!\n";
            }
            if (UpdateEngine.Text.Length > 100)
            {
                error = true;
                msgerror += "Двигатель введён не верно!\n";
            }


            
            if (UpdateBody.Text.Length < 2 && UpdateBody.Text != String.Empty)
            {
                error = true;
                msgerror += "Кузов введён не верно!\n";
            }
            if (UpdateBody.Text.Length > 100)
            {
                error = true;
                msgerror += "Кузов введён неверно!\n";
            }

           
         
             if (UpdateColor.Text.Length < 3 && UpdateColor.Text != String.Empty)
            {
                error = true;
                msgerror += "Цвет указан не верно!\n";
            }
            if (UpdateColor.Text.Length > 100)
            {
                error = true;
                msgerror += "Цвет превышает максимальное количество символов(100)!\n";
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
