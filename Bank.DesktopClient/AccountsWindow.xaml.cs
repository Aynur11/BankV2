using Bank.Dal;
using Bank.Dal.Accounts;
using System.Windows;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        public AccountsWindow()
        {
            InitializeComponent();
        }

        private void ShowAccountHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)AccountsDataGrid.SelectedValue;

            using (var repo = RepositoryFactory.GetRepository(account))
            {
                historyWindow.HistoryDataGrid.ItemsSource = repo.GetAccountHistory(account.Id);
            }

            historyWindow.ShowDialog();
        }
    }
}
