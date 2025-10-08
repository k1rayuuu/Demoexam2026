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

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для AdministratorOrderPage.xaml
    /// </summary>
    public partial class AdministratorOrderPage : Page
    {
        public AdministratorOrderPage()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += AdministratorPage_Loaded;
        }

        private void AdministratorPage_Loaded(object sender, RoutedEventArgs e)
        {
            Orders.Content = new ViewOrdersControl();
        }

        private void ViewButtonClick(object sender, RoutedEventArgs e)
        {
            Orders.Content = new ViewOrdersControl();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Orders.Content = new EditOrdersControl();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdministratorPage());
        }
    }
}
