using Bank.Dal;
using Bank.Dal.Accounts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Bank.Dal.Accounts.PhysicalPersonCreditStates;
using System.Drawing;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        private Context context;
        // Сделать параметр IRep.
        public CreditsWindow(Context context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void ShowCreditHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)CreditsDataGrid.SelectedValue;

            using (var repo = RepositoryFactory.GetRepository(account))
            {
                historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
            }

            historyWindow.ShowDialog();
        }

        private void CloseCreditMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var account = (IAccount)CreditsDataGrid.SelectedValue;
            context.CloseCredit(account);
            DataGridRow row =
                (DataGridRow)CreditsDataGrid.ItemContainerGenerator.ContainerFromItem(CreditsDataGrid.SelectedItem);

            var color = context.CloseCredit(account);
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            row.Background = new SolidColorBrush(newColor);
        }

        private void CreditsDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.DataContext is LegalPersonCredit)
            {
                return;
            }

            var row = e.Row;
            var credit = row.DataContext as PhysicalPersonCredit;
            if (Equals(sender, CreditsDataGrid))
            {
                if (credit.HasClosed)
                {
                    row.Background = new SolidColorBrush(Colors.Gray);
                }
                if (!credit.HasClosed)
                {
                    row.Background = new SolidColorBrush(Colors.Green);
                }

                if (credit.HasOverdue)
                {
                    row.Background = new SolidColorBrush(Colors.Red);
                }

            }
        }
    }
}
