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

namespace rusty.Resources.Pages.Workplaces
{
    /// <summary>
    /// Логика взаимодействия для UpdateWorkplace.xaml
    /// </summary>
    public partial class UpdateWorkplace : Window
    {
        STOModelContext db = new STOModelContext();
        public string Name;
        public string Specification;
        Workplaces Workplaces;
        public UpdateWorkplace()
        {
            InitializeComponent();
        }

        public UpdateWorkplace(string name, string specification, Workplaces workplace)
        {
            InitializeComponent();
            Name = name;
            Specification = specification;
            Workplaces = workplace;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateForm()){
                Model.Workplace UpdateWorkplace = (from workplaces in db.Workplaces
                                                   where (
                        workplaces.WorkplaceName == Name &&
                        workplaces.Specification == Specification
                                      )
                                                   select workplaces).Single();
                if (UpdateName.Text != String.Empty)
                    UpdateWorkplace.WorkplaceName = UpdateName.Text;
                if (UpdateSpecification.Text != String.Empty)
                    UpdateWorkplace.Specification = UpdateSpecification.Text;
                db.SaveChanges();
                Workplaces.a.ItemsSource = db.Workplaces.ToList();
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
            if (UpdateName.Text.Length > 50)
            {
                error = true;
                msgerror += "Название превышает максимальное количество символов (50)!\n";
            }

            if (UpdateSpecification.Text.Length > 100)
            {
                error = true;
                msgerror += "Описание превышает максимальное количество символов (100)!\n";
            }

            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка изменения", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}
