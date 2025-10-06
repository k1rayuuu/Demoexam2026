using Exam2026.Dto;
using Exam2026.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        private int _sortIndex = 0;
        public ManagerPage()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += ManagerPage_Loaded;
        }

        private void ManagerPage_Loaded(object sender, RoutedEventArgs e)
        {
            Tovars.Content = new ViewTovarsControl();
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            var items = GetItems();

            if (items is null) return;

            if (_sortIndex % 2 == 0)
            {
                var orderedItems = items.OrderBy(x => x.Наименование_товара).ToList();

                items.Clear();
                foreach (var item in orderedItems)
                {
                    items.Add(item);
                }
            }
            else
            {
                var orderedItems = items.OrderByDescending(x => x.Наименование_товара).ToList();

                items.Clear();
                foreach (var item in orderedItems)
                {
                    items.Add(item);
                }
            }

            _sortIndex++;
        }

        private ObservableCollection<TovarDto> GetItems()
        {
            if (Tovars.Content is ViewTovarsControl control)
            {
                return control.Items;
            }
            else if (Tovars.Content is EditTovarsControl)
            {
                return null;
            }

            throw new Exception();
        }

        private void SortByPrice(object sender, RoutedEventArgs e)
        {
            var items = GetItems();

            if (items is null)
                return;

            if (_sortIndex % 2 == 0)
            {
                var orderedItems = items.OrderBy(x =>
                {
                    if (double.TryParse(x.Цена, out var price))
                        return price;
                    else
                        return 0;
                }).ToList();

                items.Clear();
                foreach (var item in orderedItems)
                {
                    items.Add(item);
                }
            }
            else
            {
                var orderedItems = items.OrderByDescending(x =>
                {
                    if (double.TryParse(x.Цена, out var price))
                        return price;
                    else
                        return 0;
                }).ToList();

                items.Clear();
                foreach (var item in orderedItems)
                {
                    items.Add(item);
                }
            }

            _sortIndex++;
        }

        private void FilterItems(object sender, RoutedEventArgs e)
        {
            var items = GetItems();

            if (items is null)
                return;

            var filter = Filter.Text.ToLower();
            using (var dbContext = new AppDbContext())
            {
                var tovars = dbContext.Tovars.ToList();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    tovars = tovars.Where(x =>
                    {
                        return x.Наименование_товара.ToLower().Contains(filter) ||
                                x.Категория_товара.ToLower().Contains(filter) ||
                                x.Описание_товара.ToLower().Contains(filter);
                    }).ToList();
                }

                items.Clear();
                foreach (var tovar in tovars)
                {
                    items.Add(tovar.ToDto());
                }
            }
        }

        private void ViewButtonClick(object sender, RoutedEventArgs e)
        {
            Tovars.Content = new ViewTovarsControl();
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void OrdersButtonClick(object sender, RoutedEventArgs e)
        {
            Tovars.Content = new EditOrdersControl();
        }
    }
}
