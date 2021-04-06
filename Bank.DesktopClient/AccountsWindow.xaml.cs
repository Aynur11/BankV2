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
            var account = (IAccount) AccountsDataGrid.SelectedValue;

            if (account is PhysicalPersonAccount)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetAccountHistory(account.Id);
                }
            }
            else
            {
                using (var repo = new LegalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetAccountHistory(account.Id);
                }
            }
            historyWindow.ShowDialog();
        }
    }
}
