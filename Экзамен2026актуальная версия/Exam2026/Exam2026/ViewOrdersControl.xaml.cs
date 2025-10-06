using Exam2026.Dto;
using Exam2026.Extensions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для ViewOrdersControl.xaml
    /// </summary>
    public partial class ViewOrdersControl : UserControl
    {

        public ObservableCollection<OrderDto> Items { get; set; } = new ObservableCollection<OrderDto>();

        public ViewOrdersControl()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += ViewTovarsPage_Loaded;
        }

        private void ViewTovarsPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var orders = dbContext.Orders.ToList();

                foreach (var order in orders)
                {
                    Items.Add(order.ToDto());
                }
            }
        }
    }
}
