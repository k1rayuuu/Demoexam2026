using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для EditTovarsControl.xaml
    /// </summary>
    public partial class EditTovarsControl : UserControl
    {
        public ObservableCollection<Tovars> Items { get; set; } = new ObservableCollection<Tovars>();

        public EditTovarsControl()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += EditTovarsControlLoaded;
        }

        private void EditTovarsControlLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var tovars = dbContext.Tovars.ToList();

                foreach (var tovar in tovars)
                {
                    Items.Add(tovar);
                }
            }
        }

        private void SaveButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    dbContext.Tovars.AddOrUpdate(Items.ToArray());
                    dbContext.SaveChanges();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                MessageBox.Show("Редактирование/Добавление произошло успешно");
            }
        }
    }
}
