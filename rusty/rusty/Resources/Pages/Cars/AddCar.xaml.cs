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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        STOModelContext db = new STOModelContext();

        public AddCar()
        {
            InitializeComponent();
        }

        Cars AddPage;

        public AddCar(Cars a)
        {
            InitializeComponent();
            AddPage = a;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Car newCar = new Model.Car()
                {
                    CarMark = AddMark.Text,
                    CarModel = AddModel.Text,
                    Year = Int32.Parse(AddYear.Text),
                    Engine = AddEngine.Text,
                    Color = AddColor.Text,
                    Body = AddBody.Text,
                    RegNummber = AddRegNummber.Text
                };

                db.Cars.Add(newCar);
                db.SaveChanges();

                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (AddMark.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите марку!\n";
            }
            //else if (!AddFIO.Text.All(char.IsLetter))
            //{
            //    error = true;
            //    msgerror += "ФИО должно состоять только из букв!\n";
            //}
            else if (AddMark.Text.Length < 3)
            {
                error = true;
                msgerror += "Марка указана не верно!\n";
            }
            if (AddMark.Text.Length > 100)
            {
                error = true;
                msgerror += "Марка превышает максимальное количество символов(100)!\n";
            }

            if (AddModel.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите модель!\n";
            }
         
            else if (AddModel.Text.Length < 3)
            {
                error = true;
                msgerror += "Модель указана не верно!\n";
            }
            if (AddModel.Text.Length > 100)
            {
                error = true;
                msgerror += "Модель превышает максимальное количество символов(100)!\n";
            }


            if (AddRegNummber.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите регистрационный номер!\n";
            }

            else if (AddRegNummber.Text.Length < 3)
            {
                error = true;
                msgerror += "Регистрационный номер указан не верно!\n";
            }
            if (AddRegNummber.Text.Length > 20)
            {
                error = true;
                msgerror += "Регистрационный номер превышает максимальное количество символов(20)!\n";
            }

            if (AddYear.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите год!\n";
            }
            else if (!AddYear.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный год!\n";
            }
            else if (Single.Parse(AddYear.Text) >= 3000 || Single.Parse(AddYear.Text) < 1800)
            {
                error = true;
                msgerror += "Введен некорректный год!\n";
            }

            if (AddEngine.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите двигатель!\n";
            }
            else if (AddEngine.Text.Length < 2)
            {
                error = true;
                msgerror += "Двигатель введён не верно!\n";
            }
            if (AddEngine.Text.Length > 100)
            {
                error = true;
                msgerror += "Двигатель введён не верно!\n";
            }


            if (AddBody.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите кузов!\n";
            }
            else if (AddBody.Text.Length < 2)
            {
                error = true;
                msgerror += "Кузов введён не верно!\n";
            }
            if (AddBody.Text.Length > 100)
            { 
                error = true;
                msgerror += "Кузов введён неверно!\n";
            }

            if (AddColor.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите цвет!\n";
            }
           
            else if (AddColor.Text.Length < 3)
            {
                error = true;
                msgerror += "Цвет указан не верно!\n";
            }
            if (AddColor.Text.Length > 100)
            {
                error = true;
                msgerror += "Цвет превышает максимальное количество символов(100)!\n";
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
