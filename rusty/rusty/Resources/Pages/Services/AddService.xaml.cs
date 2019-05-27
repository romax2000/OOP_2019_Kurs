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

namespace rusty.Resources.Pages.Services
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        STOModelContext db = new STOModelContext();

        public AddService()
        {
            InitializeComponent();
        }

        Services AddPage;

        public AddService(Services a)
        {
            InitializeComponent();
            AddPage = a;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Service newService = new Model.Service()
                {
                    ServiceName = AddName.Text,
                    Cost = Single.Parse(AddCost.Text)

                };

                db.Services.Add(newService);
                db.SaveChanges();
                Services.a.ItemsSource = db.Services.ToList();
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
                msgerror += "Введите название услуги!\n";
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
            if (AddCost.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите цену!\n";
            }
            else if (!AddCost.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
            else if (Single.Parse(AddCost.Text) >= 100000 || Single.Parse(AddCost.Text) <= 0)
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
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
