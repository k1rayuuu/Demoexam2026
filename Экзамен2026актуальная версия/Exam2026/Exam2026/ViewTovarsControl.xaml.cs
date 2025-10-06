using Exam2026.Dto;
using Exam2026.Extensions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для ViewTovarsControl.xaml
    /// </summary>
    public partial class ViewTovarsControl : UserControl
    {

        public ObservableCollection<TovarDto> Items { get; set; } = new ObservableCollection<TovarDto>();

        public ViewTovarsControl()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += ViewTovarsPage_Loaded;
        }

        private void ViewTovarsPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var tovars = dbContext.Tovars.ToList();

                foreach (var tovar in tovars)
                {
                    Items.Add(tovar.ToDto());
                }
            }
        }
    }
}
