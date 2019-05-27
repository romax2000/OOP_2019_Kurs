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
    /// Логика взаимодействия для UpdateService.xaml
    /// </summary>
    public partial class UpdateService : Window
    {
        STOModelContext db = new STOModelContext();
        public string Name;
        public Single Cost;
        Services Service;
        public UpdateService()
        {
            InitializeComponent();
        }

        public UpdateService(string name, Single cost, Services service)
        {
            InitializeComponent();
            Name = name;
            Cost = cost;
            Service = service;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Model.Service UpdateService = (from services in db.Services
                                               where (
                    services.ServiceName == Name &&
                    services.Cost == Cost
                                  )
                                               select services).Single();
                if (UpdateName.Text != String.Empty)
                    UpdateService.ServiceName = UpdateName.Text;
                if (UpdateCost.Text != String.Empty)
                    UpdateService.Cost = Single.Parse(UpdateCost.Text);
                db.SaveChanges();
                Services.a.ItemsSource = db.Services.ToList();
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
            if (!UpdateCost.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
            else if (UpdateCost.Text != String.Empty)
            { 
            if (Single.Parse(UpdateCost.Text) >= 100000 || Single.Parse(UpdateCost.Text) <= 0)
            {
                error = true;
                msgerror += "Введена некорректная цена!\n";
            }
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
