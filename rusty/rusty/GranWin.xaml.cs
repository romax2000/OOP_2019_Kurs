using rusty.Resources.Pages.Help;
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

namespace rusty
{
    /// <summary>
    /// Логика взаимодействия для GranWin.xaml
    /// </summary>
    public partial class GranWin : Window
    {
        
        public GranWin()
        {
            InitializeComponent();
            MyFrame.Navigate(new System.Uri("Resources/Pages/GranPage/GranPage.xaml", UriKind.RelativeOrAbsolute));
        }


        private void Color_MouseEnter(object sender, MouseEventArgs e)
        {
           
            ((ListViewItem)sender).Foreground = Brushes.Yellow;
        }

        private void Color_MouseLeave(object sender, MouseEventArgs e)
        {
            ((ListViewItem)sender).Foreground = Brushes.White;
        }

       
      
        private void Requests_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Requests/Requests.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Orders_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Orders/Orders.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Storage_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Storage/Storage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Masters_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Masters/Masters.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Customers_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Customers/Customers.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Workplaces_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Workplaces/Workplaces.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Cars_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Cars/Cars.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void Supply_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Supply/Supply.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Shippers_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Shippers/Shippers.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Go_inside_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.current_user == "user")
                MyFrame.Navigate(new System.Uri("Resources/Pages/Office/Office.xaml", UriKind.RelativeOrAbsolute));
            if(MainWindow.current_user == "master")
               MyFrame.Navigate(new System.Uri("Resources/Pages/Office/OfficeMaster.xaml", UriKind.RelativeOrAbsolute));
            if (MainWindow.current_user == "admin")
                MyFrame.Navigate(new System.Uri("Resources/Pages/Office/OfficeAdmin.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Users_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Users/Users.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Start();
            timer.Interval=new TimeSpan(0,0,1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) =>
            {
                GetTime.Content = DateTime.Now.ToString("HH:mm:ss");
                GetDate.Content = DateTime.Now.ToString("ddd MMM yyy");
            };
        }

        public void Go_out_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void To_gran_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/GranPage/GranPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Service_Selected(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new System.Uri("Resources/Pages/Services/Services.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Readme_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\VBOXSVR\Dokuments\ООП\Курсач Ржавый\Readme.docx");
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Help open = new Help();
            open.Show();
        }

        
    }
}
 