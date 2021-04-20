using Bank.Bll;
using Bank.Dal;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.Exceptions;
using Bank.DesktopClient.AddingAccountWindow;
using Bank.DesktopClient.AddingLegalPersonCredit;
using Bank.DesktopClient.LegalPersonClientWindow;
using Bank.DesktopClient.PhysicalPersonClientWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Bank.Dal.Accounts.PhysicalPersonCreditStates;
using Bank.DesktopClient.AddingPhysicalPersonCredit;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window, INotifyPropertyChanged
    {
        private Context context;
        public ObservableCollection<PhysicalPersonClient> PhysicalPersonClients { get; set; }
        public PhysicalPersonClient SelectedPhysicalPersonClient { get; set; }
        public ObservableCollection<LegalPersonClient> LegalPersonClients { get; set; }
        public LegalPersonClient SelectedLegalPersonClient { get; set; }

        private readonly IRate rate;
        public ClientsWindow(IRate rate)
        {
            InitializeComponent();
            this.rate = rate;
            context = new Context(new RepaidState());
            //TestData testData = new TestData();
            //testData.FillAllTables();
            using (var repo = new PhysicalPersonClientRepository())
            {
                PhysicalPersonClients = new ObservableCollection<PhysicalPersonClient>(repo.GetClients());
                PhysicalPersonsDataGrid.DataContext = this;
            }

            using (var repo = new LegalPersonClientRepository())
            {
                LegalPersonClients = new ObservableCollection<LegalPersonClient>(repo.GetClients());
                LegalPersonsDataGrid.DataContext = this;
            }
        }

        private void OpenPhysicalPersonAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                IAccount account = new PhysicalPersonAccount();
                AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow(account, client.Id);
                accountWindow.CapitalizationCheckBox.IsEnabled = false;
                accountWindow.PeriodTextBox.IsEnabled = false;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new PhysicalPersonClientRepository())
                    {
                        account = new PhysicalPersonAccount(client.Id, accountWindow.GetAccount.Currency, accountWindow.GetAccount.Amount);
                        repo.AddAccount(account);
                        SelectedPhysicalPersonClient.Accounts.Add((PhysicalPersonAccount)account);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void OpenLegalPersonAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                IAccount account = new LegalPersonAccount();
                AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow(account, client.Id);
                accountWindow.CapitalizationCheckBox.IsEnabled = false;
                accountWindow.PeriodTextBox.IsEnabled = false;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {
                        account = new LegalPersonAccount(client.Id, accountWindow.GetAccount.Currency, accountWindow.GetAccount.Amount);
                        repo.AddAccount(account);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void OpenPhysicalPersonDepositButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                IAccount account = new PhysicalPersonDeposit();
                AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow(account, client.Id);
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new PhysicalPersonClientRepository())
                    {
                        repo.AddDeposit(client.Id, accountWindow.GetAccount.Currency, accountWindow.GetAccount.Amount, accountWindow.Period,
                            accountWindow.WithCapitalization, rate.CalcPhysicalPersonDepositRate(client.Type));
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void OpenLegalPersonDepositButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                IAccount account = new LegalPersonDeposit();
                AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow(account, client.Id);
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {
                        repo.AddDeposit(client.Id, accountWindow.GetAccount.Currency, accountWindow.GetAccount.Amount, accountWindow.Period,
                            accountWindow.WithCapitalization, rate.CalcLegalPersonDepositRate(client.Type));
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void IssuePhysicalPersonCreditButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                IAccount account = new PhysicalPersonCredit();
                AddingPhysicalPersonCreditWindow addingPhysicalPersonCreditWindow = new AddingPhysicalPersonCreditWindow(account, client.Id);

                if (addingPhysicalPersonCreditWindow.ShowDialog() == true)
                {
                    context = new Context(new IssuedState());
                    context.IssueCredit(client.Id, addingPhysicalPersonCreditWindow.GetAccount.Currency, addingPhysicalPersonCreditWindow.GetAccount.Amount,
                        addingPhysicalPersonCreditWindow.Period, rate.CalcPhysicalPersonCreditRate(client.Type));
                    //using (var repo = new PhysicalPersonClientRepository())
                    //{
                    //    repo.AddCredit(client.Id, addingPhysicalPersonCreditWindow.GetAccount.Currency, addingPhysicalPersonCreditWindow.GetAccount.Amount, addingPhysicalPersonCreditWindow.Period,
                    //        rate.CalcPhysicalPersonCreditRate(client.Type));
                    //}
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void IssueLegalPersonCreditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                IAccount account = new LegalPersonCredit();
                AddingLegalPersonCreditWindow addingPhysicalPersonCreditWindow = new AddingLegalPersonCreditWindow(account, client.Id);
                if (addingPhysicalPersonCreditWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {

                        repo.AddCredit(client.Id, addingPhysicalPersonCreditWindow.Currency, addingPhysicalPersonCreditWindow.GetAccount.Amount, addingPhysicalPersonCreditWindow.Period,
                            rate.CalcLegalPersonCreditRate(client.Type));
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void TransferPhysicalPersonMoneyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MoneyTransferWindow moneyTransferWindow = new MoneyTransferWindow();
            using (var physicalPersonClientRepo = new PhysicalPersonClientRepository())
            using (var legalPersonClientRepo = new LegalPersonClientRepository())
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = client.Accounts;
                moneyTransferWindow.SenderAccountIdComboBox.DisplayMemberPath = "Id";

                var allClients = new List<IClient>();
                allClients.AddRange(physicalPersonClientRepo.GetClients());
                allClients.AddRange(legalPersonClientRepo.GetClients());

                moneyTransferWindow.RecipientClientNamesComboBox.ItemsSource = allClients;
                moneyTransferWindow.RecipientClientNamesComboBox.DisplayMemberPath = "DisplayName";

                if (moneyTransferWindow.ShowDialog() == true)
                {
                    IAccount accountFrom = (IAccount)moneyTransferWindow.SenderAccountIdComboBox.SelectedValue;
                    IAccount accountTo = (IAccount)moneyTransferWindow.RecipientAccountsIdComboBox.SelectedValue;
                    try
                    {
                        AccountManager accountManager = new AccountManager();
                        accountManager.TransferMoney(accountFrom, accountTo, moneyTransferWindow.Amount);
                        physicalPersonClientRepo.Save();
                        legalPersonClientRepo.Save();
                    }
                    catch (HimselfTransferException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\n" +
                                        $"Перевод с клиента {accountFrom.ClientId} со счета {accountFrom.Id} клиенту {accountTo.ClientId} на счет {accountTo.Id}");
                    }
                    catch (InsufficientAmountsException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\nСуммма денег на счету: {exception.Amount}");
                    }
                    catch (CurrencyMismatchException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\n" +
                                        $"Валюта счета отправителя: {exception.Sender}, валюта счета получателя: {exception.Recipient}");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message} Выполняем завершение программы.");
                        throw;
                    }
                }
            }
        }

        private void TransferLegalPersonMoneyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MoneyTransferWindow moneyTransferWindow = new MoneyTransferWindow();
            using (var physicalPersonClientRepo = new PhysicalPersonClientRepository())
            using (var legalPersonClientRepo = new LegalPersonClientRepository())
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = client.Accounts;
                moneyTransferWindow.SenderAccountIdComboBox.DisplayMemberPath = "Id";

                var allClients = new List<IClient>();
                allClients.AddRange(physicalPersonClientRepo.GetClients());
                allClients.AddRange(legalPersonClientRepo.GetClients());

                moneyTransferWindow.RecipientClientNamesComboBox.ItemsSource = allClients;
                moneyTransferWindow.RecipientClientNamesComboBox.DisplayMemberPath = "DisplayName";

                if (moneyTransferWindow.ShowDialog() == true)
                {
                    IAccount accountFrom = (IAccount)moneyTransferWindow.SenderAccountIdComboBox.SelectedValue;
                    IAccount accountTo = (IAccount)moneyTransferWindow.RecipientAccountsIdComboBox.SelectedValue;
                    try
                    {
                        AccountManager accountManager = new AccountManager();
                        accountManager.TransferMoney(accountFrom, accountTo, moneyTransferWindow.Amount);
                        physicalPersonClientRepo.Save();
                        legalPersonClientRepo.Save();

                    }
                    catch (InsufficientAmountsException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\nСуммма денег на счету: {exception.Amount}");
                    }
                    catch (CurrencyMismatchException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\n" +
                                        $"Валюта счета отправителя: {exception.Sender}, валюта счета получателя: {exception.Recipient}");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message} Выполняем завершение программы.");
                        throw;
                    }
                }
            }
        }

        private void RemovePhysicalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (var repo = new PhysicalPersonClientRepository())
            {
                repo.RemoveClient(SelectedPhysicalPersonClient);
                repo.Save();
                repo.Update(SelectedPhysicalPersonClient);
            }

            PhysicalPersonClients.Remove(SelectedPhysicalPersonClient);
        }

        private void RemoveLegalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (var repo = new LegalPersonClientRepository())
            {
                repo.RemoveClient(SelectedLegalPersonClient);
                repo.Save();
                repo.Update(SelectedLegalPersonClient);
            }

            LegalPersonClients.Remove(SelectedLegalPersonClient);
        }

        private void PhysicalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (SelectedPhysicalPersonClient != null)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    repo.Update(SelectedPhysicalPersonClient);
                    repo.Save();
                }
            }
        }

        private void LegalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (SelectedLegalPersonClient != null)
            {
                using (var repo = new LegalPersonClientRepository())
                {
                    repo.Update(SelectedLegalPersonClient);
                    repo.Save();
                }
            }
        }

        private void AddNewPhysicalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addingClientWindow = new AddingPhysicalPersonClientWindow();
            if (addingClientWindow.ShowDialog() == true)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    if (!DateTime.TryParse(addingClientWindow.BirthdayTextBox.Text, out var birthday))
                    {
                        MessageBox.Show("Ошибка ввода дня рождения");
                        return;
                    }

                    ClientType clientType = Convert.ToBoolean(addingClientWindow.IsVipCheckBox.IsChecked)
                        ? ClientType.Vip
                        : ClientType.Usual;

                    var client = new PhysicalPersonClient(addingClientWindow.FirstNameTextBox.Text, 
                        addingClientWindow.LastNameTextBox.Text, 
                        addingClientWindow.LastNameTextBox.Text,
                        birthday,
                        clientType);
                    PhysicalPersonClients.Add(client);
                    repo.AddClient(client);
                    repo.Save();
                }
            }
        }

        private void AddNewLegalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addingClientWindow = new AddingLegalPersonClientWindow();
            if (addingClientWindow.ShowDialog() == true)
            {
                using (var repo = new LegalPersonClientRepository())
                {
                    ClientType clientType = Convert.ToBoolean(addingClientWindow.IsVipCheckBox.IsChecked)
                        ? ClientType.Vip
                        : ClientType.Usual;

                    var client = new LegalPersonClient(addingClientWindow.CompanyNameTextBox.Text, clientType);
                    LegalPersonClients.Add(client);
                    repo.AddClient(client);
                    repo.Save();
                }
            }
        }

        private void ShowAllPhysicalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedPhysicalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var creditsWindow = new CreditsWindow(context);
            creditsWindow.Title = $"Все кредиты клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                creditsWindow.CreditsDataGrid.DataContext = SelectedPhysicalPersonClient.Credits;
                creditsWindow.ShowDialog();
            }
        }

        private void ShowAllLegalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedLegalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var creditsWindow = new CreditsWindow(context);
            creditsWindow.Title = $"Все кредиты клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                creditsWindow.CreditsDataGrid.DataContext = SelectedLegalPersonClient.Credits;
                creditsWindow.ShowDialog();
            }
        }

        private void ShowAllPhysicalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedPhysicalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var depositsWindow = new DepositsWindow();
            depositsWindow.Title = $"Все деопзиты клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                depositsWindow.DepositsDataGrid.DataContext = SelectedPhysicalPersonClient.Deposits;
                depositsWindow.ShowDialog();
            }
        }
        private void ShowAllLegalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedLegalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var depositsWindow = new DepositsWindow();
            depositsWindow.Title = $"Все деопзиты клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                depositsWindow.DepositsDataGrid.DataContext = SelectedLegalPersonClient.Deposits;
                depositsWindow.ShowDialog();
            }
        }

        private void ShowAllPhysicalPersonAccountsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedPhysicalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var accountsWindow = new AccountsWindow();
            accountsWindow.Title = $"Все счета клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                accountsWindow.AccountsDataGrid.DataContext = SelectedPhysicalPersonClient.Accounts;
                accountsWindow.ShowDialog();
            }
        }

        private void ShowAllLegalPersonAccountsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedLegalPersonClient == null)
            {
                MessageBox.Show("Выберите клиента корректным образом!");
                return;
            }
            var accountsWindow = new AccountsWindow();
            accountsWindow.Title = $"Все счета клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                accountsWindow.AccountsDataGrid.DataContext = SelectedLegalPersonClient.Accounts;
                accountsWindow.ShowDialog();
            }
        }

        private void ShowAllAccountsWithClientsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var accounts = new AccountsWithClientsWindow();
            using (var repo = new CommonRepository())
            {
                accounts.AccountsWithClientsDataGrid.ItemsSource = repo.GetAccountsWithClients();
                accounts.ShowDialog();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
