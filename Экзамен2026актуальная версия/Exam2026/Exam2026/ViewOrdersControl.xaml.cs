using Exam2026.Dto;
using Exam2026.Extensions;
using System;
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
        // Строка привязки даннвх, позволяет уведомлять  об изменениях в коллекции(добавление, удаление)
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
                    var pickUpPoint = dbContext.PickUpPoints.FirstOrDefault(x => x.Id == order.Адрес_пункта_выдачи);
                    if (pickUpPoint is null)
                    {
                        throw new ArgumentException();
                    }
                    Items.Add(order.ToDto(pickUpPoint));
                }
            }
        }
    }
}
