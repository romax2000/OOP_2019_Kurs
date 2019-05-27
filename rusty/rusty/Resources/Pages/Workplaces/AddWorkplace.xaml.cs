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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rusty.Resources.Pages.Workplaces
{
    /// <summary>
    /// Логика взаимодействия для AddWorkplase.xaml
    /// </summary>
    public partial class AddWorkplace : Window
    {
        STOModelContext db = new STOModelContext();

        public AddWorkplace()
        {
            InitializeComponent();
        }

        Workplaces AddPage;

        public AddWorkplace(Workplaces a)
        {
            InitializeComponent();
            AddPage = a;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Workplace newWorkplase = new Model.Workplace()
                {
                    WorkplaceName = AddName.Text,
                    Specification = AddSpecification.Text,

                };

                db.Workplaces.Add(newWorkplase);
                db.SaveChanges();
                Workplaces.a.ItemsSource = db.Workplaces.ToList();
                this.Hide();
            }
        }
        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;
            if(AddName.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите название рабочего места!\n";
            }
            else if(AddName.Text.Length < 3)
            {
                error = true;
                msgerror += "Название должно состоять минимум из 3-х символов!\n";
            }
            if(AddName.Text.Length > 50)
            {
                error = true;
                msgerror += "Название превышает максимальное количество символов (50)!\n";
            }

            if (AddSpecification.Text.Length > 100)
            {
                error = true;
                msgerror += "Описание превышает максимальное количество символов (100)!\n";
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
