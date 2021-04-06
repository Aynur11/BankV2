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

        private void ShowDepositMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)DepositsDataGrid.SelectedValue;

            if (account is PhysicalPersonDeposit)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetDepositHistory(account.Id);
                }
            }
            else
            {
                using (var repo = new LegalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetDepositHistory(account.Id);
                }
            }

            historyWindow.ShowDialog();
        }
    }
}
