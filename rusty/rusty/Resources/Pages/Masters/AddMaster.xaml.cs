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

namespace rusty.Resources.Pages.Masters
{
    /// <summary>
    /// Логика взаимодействия для AddMaster.xaml
    /// </summary>
    public partial class AddMaster : Window
    {
        STOModelContext db = new STOModelContext();

        public AddMaster()
        {
            InitializeComponent();
        }

        Masters AddPage;

        public AddMaster(Masters a)
        {
            InitializeComponent();
            AddPage = a;
            ComboboxWorkplace();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string workname = AddWorkplace.Text;
                AddWorkplace.DisplayMemberPath = "WorkplaceId";
                Model.Master newMaster = new Model.Master()
                {
                    Login = AddLogin.Text,
                    FIO = AddFIO.Text,
                    Spec = AddSpec.Text,
                    Exp = Int32.Parse(AddExp.Text),
                    Phone = AddPhone.Text,
                    WorkplaceId = Int32.Parse(AddWorkplace.Text),
                    Salary = Single.Parse(AddSalary.Text),
                    WorkplaseName = workname
                };
                db.Masters.Add(newMaster);
                db.SaveChanges();
                Masters.a.ItemsSource = db.Masters.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

            if (AddFIO.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите ФИО!\n";
            }
           
            else if (AddFIO.Text.Length < 3)
            {
                error = true;
                msgerror += "ФИО указано не верно!\n";
            }
            if (AddFIO.Text.Length > 100)
            {
                error = true;
                msgerror += "ФИО превышает максимальное количество символов(100)!\n";
            }

            if (AddLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(AddLogin.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(AddLogin.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(AddLogin.Text)).FirstOrDefault();
                if ((user != null && master != null) || (user != null && customer != null) || master != null || customer != null)

                {
                    error = true;
                    msgerror += "Такой логин уже существует!\n";
                }
            }

            if (AddLogin.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите логин!\n";
            }
            else if (AddLogin.Text.Length < 4)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }

            if (AddLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }

            if (AddSpec.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите специальность!\n";
            }
           
            else if (AddSpec.Text.Length < 3)
            {
                error = true;
                msgerror += "Специальность указана не верно!\n";
            }
            if (AddSpec.Text.Length > 100)
            {
                error = true;
                msgerror += "Специальность превышает максимальное количество символов(100)!\n";
            }

            if (AddExp.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите стаж!\n";
            }
            else if (!AddExp.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный стаж!\n";
            }
            else if (Single.Parse(AddExp.Text) >= 100 || Single.Parse(AddExp.Text) < 0)
            {
                error = true;
                msgerror += "Введен некорректный стаж!\n";
            }

            if (AddPhone.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите номер телефона!\n";
            }
            else if (AddPhone.Text.Length < 5)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (AddPhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }
            if (AddWorkplace.Text == String.Empty)
            {
                error = true;
                msgerror += "Выберите рабочее место!\n";
            }

            if (AddSalary.Text == String.Empty)
            {
                error = true;
                msgerror += "Введите зарплату!\n";
            }
            else if (!AddSalary.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введена некорректная зарплата!\n";
            }
            else if (Single.Parse(AddSalary.Text) >= 100000 || Single.Parse(AddSalary.Text) < 50)
            {
                error = true;
                msgerror += "Введена некорректная зарплата!\n";
            }



            if (error)
            {
                rusty.Resources.Style.CustomMessageBox.CustomMessageBox.Show("Ошибка добавления", msgerror, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        public void ComboboxWorkplace()
        {
            AddWorkplace.ItemsSource = db.Workplaces.ToList();

        }
    }
}
