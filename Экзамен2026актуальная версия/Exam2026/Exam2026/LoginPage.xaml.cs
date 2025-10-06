using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Exam2026
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        private readonly MainWindow _parent;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public LoginPage(MainWindow parent)
        {
            _parent = parent;
            InitializeComponent();
            DataContext = this;
            
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Логин == Login && u.Пароль == Password);

                if (user is null)
                {
                    MessageBox.Show("Не удалось найти пользователя с такими данными");
                    return;
                }

                _parent.UserName = user.ФИО;

                switch (user.Роль_сотрудника)
                {
                    case "Администратор":
                        this.NavigationService.Navigate(new AdministratorPage());
                        break;
                    case "Менеджер":
                        this.NavigationService.Navigate(new ManagerPage());
                        break;
                    case "Авторизированный клиент":
                        this.NavigationService.Navigate(new GuestPage());
                        break;
                    default:
                        MessageBox.Show($"функционал на роль - {user.Роль_сотрудника} не реализован");
                        break;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void GuestSignIn(object sender, RoutedEventArgs e)
        {
            _parent.UserName = "Гость";
            this.NavigationService.Navigate(new GuestPage());
        }
    }
}
