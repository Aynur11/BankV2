using System.Windows;
using Autofac;
using Bank.Bll;
using Bank.DesktopClient.Util;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = AutofacConfig.ConfigureContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<ClientsWindow>();
                window.Show();
            }
        }
    }
}
