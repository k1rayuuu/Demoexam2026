using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для EditOrdersControl.xaml
    /// </summary>
    public partial class EditOrdersControl : UserControl
    {
        public ObservableCollection<Orders> Items { get; set; } = new ObservableCollection<Orders>();

        public EditOrdersControl()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += EditTovarsControlLoaded;
        }

        private void EditTovarsControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var orders = dbContext.Orders.ToList();

                foreach (var order in orders)
                {
                    Items.Add(order);
                }
            }
        }

        private void SaveButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    dbContext.Orders.AddOrUpdate(Items.ToArray());
                    dbContext.SaveChanges();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                MessageBox.Show("Редактирование/Добавление произошло успешно");
            }
        }
    }
}
