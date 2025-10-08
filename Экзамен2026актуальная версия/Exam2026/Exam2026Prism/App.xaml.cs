using Exam2026Prism.ViewModels;
using Exam2026Prism.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Exam2026Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AuthorizationView, AuthorizationViewModel> ();
        }
    }

}
