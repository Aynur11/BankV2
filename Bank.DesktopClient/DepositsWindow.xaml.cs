using Bank.Dal;
using Bank.Dal.Accounts;
using System.Windows;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for DepositsWindow.xaml
    /// </summary>
    public partial class DepositsWindow : Window
    {
        public DepositsWindow()
        {
            InitializeComponent();
        }

        private void ShowDepositHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)DepositsDataGrid.SelectedValue;

            using (var repo = RepositoryFactory.GetRepository(account))
            {
                historyWindow.HistoryDataGrid.ItemsSource = repo.GetDepositHistory(account.Id);
            }

            historyWindow.ShowDialog();
        }
    }
}
