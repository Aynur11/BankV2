using Bank.Dal;
using Bank.Dal.Accounts;
using System.Windows;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        // Сделать параметр IRep.
        public CreditsWindow()
        {
            InitializeComponent();
        }

        private void ShowCreditHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)CreditsDataGrid.SelectedValue;

            using (var repo = RepositoryFactory.GetRepository(account))
            {
                historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
            }

            //if (account is PhysicalPersonCredit)
            //{
            //    using (var repo = RepositoryFactory.GetRepository(account))
            //    {
            //        historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
            //    }
            //}
            //else
            //{
            //    using (var repo = RepositoryFactory.GetRepository(typeof(LegalPersonClientRepository)))
            //    {
            //        historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
            //    }
            //}

            historyWindow.ShowDialog();
        }
    }
}
