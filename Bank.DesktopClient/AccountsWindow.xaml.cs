using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Bank.Dal;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        public ObservableCollection<PhysicalPersonAccount> Accounts { get; set; }
        public PhysicalPersonAccount SelectedAccount { get; set; }

        public AccountsWindow(int clientId)
        {
            InitializeComponent();
            using (var repo = new PhysicalPersonClientRepository())
            {
                Accounts = new ObservableCollection<PhysicalPersonAccount>(repo.GetAllClientAccounts(clientId));
                AccountsDataGrid.DataContext = this;
            }
        }

        private void ShowAccountHistoryMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var historyWindow = new AccountHistoryWindow();

            using (var repo = new PhysicalPersonClientRepository())
            {
                if (SelectedAccount == null)
                {
                    Debug.WriteLine("Счет не выбран");
                    return;
                }
                historyWindow.AccountsDataGrid.ItemsSource = repo.GetAccountHistory(SelectedAccount.Id);
                historyWindow.ShowDialog();
            }
            
        }
    }
}
