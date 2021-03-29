using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bank.Dal;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        public CreditsWindow()
        {
            InitializeComponent();
        }

        private void ShowCreditHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();
            var account = (IAccount)CreditsDataGrid.SelectedValue;

            if (account is PhysicalPersonAccount ||
                account is PhysicalPersonDeposit ||
                account is PhysicalPersonCredit)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
                }
            }
            else
            {
                using (var repo = new LegalPersonClientRepository())
                {
                    historyWindow.HistoryDataGrid.ItemsSource = repo.GetCreditHistory(account.Id);
                }
            }

            historyWindow.ShowDialog();
        }
    }
}
