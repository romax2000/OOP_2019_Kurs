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
    /// Логика взаимодействия для UpdateMaster.xaml
    /// </summary>
    public partial class UpdateMaster : Window
    {
        STOModelContext db = new STOModelContext();
        public string Login;
        public string FIO;
        public string Spec;
        public int Exp;
        public string Phone;
        public int WorkplaceId;
        public string WorkplaceName;
        public Single Salary;
        Masters Master;
        public UpdateMaster()
        {
            InitializeComponent();
        }

        public UpdateMaster(string log, string fio, string spec, int exp, string phone, int id, Single salary, string workname, Masters master)
        {
            InitializeComponent();
            Login = log;
            FIO = fio;
            Spec = spec;
            Exp = exp;
             Phone= phone;
           WorkplaceId = id;
            Salary = salary;
            WorkplaceName = workname;
            Master = master;
            ComboboxWorkplace();

        }
        public void ComboboxWorkplace()
        {
            UpdateWorkplace.ItemsSource = db.Workplaces.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                string workplacename = UpdateWorkplace.Text;
                UpdateWorkplace.DisplayMemberPath = "WorkplaceId";
                Model.Master UpdateMaster = (from master in db.Masters
                                             where (
                  master.Login == Login &&
                  master.FIO == FIO &&
                  master.Spec == Spec &&
                  master.Exp == Exp &&
                  master.Phone == Phone &&
                  master.WorkplaceId == WorkplaceId &&
                  master.Salary == Salary &&
                  master.WorkplaseName == WorkplaceName
                  )
                                             select master).Single();
                if (UpdateLogin.Text != String.Empty)
                    UpdateMaster.Login = UpdateLogin.Text;
                if (UpdateFIO.Text != String.Empty)
                    UpdateMaster.FIO = UpdateFIO.Text;
                if (UpdateSpec.Text != String.Empty)
                    UpdateMaster.Spec = UpdateSpec.Text;
                if (UpdateExp.Text != String.Empty)
                    UpdateMaster.Exp = Int32.Parse(UpdateExp.Text);
                if (UpdatePhone.Text != String.Empty)
                    UpdateMaster.Phone = UpdatePhone.Text;
                if (UpdateWorkplace.Text != String.Empty)
                {
                    UpdateMaster.WorkplaceId = Int32.Parse(UpdateWorkplace.Text);
                    UpdateMaster.WorkplaseName = workplacename;
                }
                if (UpdateSalary.Text != String.Empty)
                    UpdateMaster.Salary = Single.Parse(UpdateSalary.Text);
                db.SaveChanges();
                Masters.a.ItemsSource = db.Masters.ToList();
                this.Hide();
            }
        }

        private bool ValidateForm()
        {
            string msgerror = "";
            bool error = false;

           
            if (UpdateFIO.Text.Length < 3 && UpdateFIO.Text != String.Empty)
            {
                error = true;
                msgerror += "ФИО указано не верно!\n";
            }
            if (UpdateFIO.Text.Length > 100)
            {
                error = true;
                msgerror += "ФИО превышает максимальное количество символов(100)!\n";
            }

            if (UpdateLogin.Text != String.Empty)
            {
                var user = db.Users.Where(d => (d.Lonin).Equals(UpdateLogin.Text)).FirstOrDefault();
                var master = db.Masters.Where(d => (d.Login).Equals(UpdateLogin.Text)).FirstOrDefault();
                var customer = db.Customers.Where(d => (d.Login).Equals(UpdateLogin.Text)).FirstOrDefault();
                if ((user != null && master != null) || (user != null && customer != null) || master != null || customer != null)

                {
                    error = true;
                    msgerror += "Такой логин уже существует!\n";
                }
            }

          
            if (UpdateLogin.Text.Length < 4 && UpdateLogin.Text != String.Empty)
            {
                error = true;
                msgerror += "Логин должен состоять минимум из 4-х символов!\n";
            }

            if (UpdateLogin.Text.Length > 12)
            {
                error = true;
                msgerror += "Логин превышает максимальное количество символов (12)!\n";
            }

          

            else if (UpdateSpec.Text.Length < 3 && UpdateSpec.Text != String.Empty)
            {
                error = true;
                msgerror += "Специальность указана не верно!\n";
            }
            if (UpdateSpec.Text.Length > 100)
            {
                error = true;
                msgerror += "Специальность превышает максимальное количество символов(100)!\n";
            }

           
            if (!UpdateExp.Text.All(char.IsDigit))
            {
                error = true;
                msgerror += "Введен некорректный стаж!\n";
            }
            else if (UpdateExp.Text != String.Empty)
            {
                if (Single.Parse(UpdateExp.Text) >= 100 || Single.Parse(UpdateExp.Text) < 0)
                {
                    error = true;
                    msgerror += "Введен некорректный стаж!\n";
                }
            }

           
            if (UpdatePhone.Text.Length < 5 && UpdatePhone.Text != String.Empty)
            {
                error = true;
                msgerror += "Номер телефона должен состоять минимум из 5-х символов!\n";
            }
            if (UpdatePhone.Text.Length > 20)
            {
                error = true;
                msgerror += "Номер телефона превышает максимальное количество символов (20)!\n";
            }


            else if (UpdateSalary.Text != String.Empty)
            {
                if (Single.Parse(UpdateSalary.Text) >= 100000 || Single.Parse(UpdateSalary.Text) < 50)
                {
                    error = true;
                    msgerror += "Введена некорректная зарплата!\n";
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
