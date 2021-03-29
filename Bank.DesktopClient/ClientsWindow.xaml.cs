using Bank.Bll;
using Bank.Dal;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Bank.DesktopClient.PhysicalPersonClientWindow;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ObservableCollection<PhysicalPersonClient> PhysicalPersonClients { get; set; }
        public PhysicalPersonClient SelectedPhysicalPersonClient { get; set; }
        public ObservableCollection<LegalPersonClient> LegalPersonClients { get; set; }
        public LegalPersonClient SelectedLegalPersonClient { get; set; }
        private readonly Rate rate;
        private DataRowView row;

        public ClientsWindow()
        {
            Console.WriteLine(!(true ^ false));
            InitializeComponent();
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
            rate = new Rate();
        }

        private void OpenPhysicalPersonAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            accountWindow.CapitalizationCheckBox.IsEnabled = false;
            accountWindow.PeriodTextBox.IsEnabled = false;
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new PhysicalPersonClientRepository())
                    {
                        repo.AddAccount(client.Id, accountWindow.Currency, accountWindow.Amount);
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
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            accountWindow.CapitalizationCheckBox.IsEnabled = false;
            accountWindow.PeriodTextBox.IsEnabled = false;
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {
                        repo.AddAccount(client.Id, accountWindow.Currency, accountWindow.Amount);
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
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new PhysicalPersonClientRepository())
                    {
                        repo.AddDeposit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period,
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
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {
                        repo.AddDeposit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period,
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
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            accountWindow.CapitalizationCheckBox.IsEnabled = false;
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new PhysicalPersonClientRepository())
                    {
                        repo.AddCredit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period,
                            rate.CalcPhysicalPersonCreditRate(client.Type));
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите нужного клиента!");
            }
        }

        private void IssueLegalPersonCreditButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            accountWindow.CapitalizationCheckBox.IsEnabled = false;
            if (LegalPersonsDataGrid.CurrentItem != null)
            {
                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                if (accountWindow.ShowDialog() == true)
                {
                    using (var repo = new LegalPersonClientRepository())
                    {

                        repo.AddCredit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period,
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
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = physicalPersonClientRepo.GetAllClientAccounts(client.Id);
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
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = legalPersonClientRepo.GetAllClientAccounts(client.Id);
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

            PhysicalPersonClients.Remove(SelectedPhysicalPersonClient);
        }

        private void PhysicalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //if (SelectedPhysicalPersonClient != null)
            //{
            //    row = (DataRowView)PhysicalPersonsDataGrid.SelectedItem;
            //    row.BeginEdit();
            //}
            //if (SelectedPhysicalPersonClient != null)
            //{
            //    using (var repo = new PhysicalPersonClientRepository())
            //    {
            //        repo.Update(SelectedPhysicalPersonClient);
            //        repo.Save();
            //    }
            //}
        }

        private void PhysicalPersonsDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {
            //if (row == null)
            //{
            //    return;
            //}
            //row.EndEdit();
            if (SelectedPhysicalPersonClient != null)
            {
                using (var repo = new PhysicalPersonClientRepository())
                {
                    repo.Update(SelectedPhysicalPersonClient);
                    repo.Save();
                }
            }
        }

        private void LeaglPersonsDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
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

        private void LegalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void AddNewPhysicalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addingClientWindow = new AddingPhysicalPersonClientWindow();
            if (addingClientWindow.ShowDialog() == true)
            {
                //addingClientWindow.
            }

        }

        private void AddNewLegalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowAllPhysicalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var creditsWindow = new CreditsWindow();
            creditsWindow.Title = $"Все кредиты клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                creditsWindow.CreditsDataGrid.DataContext = repo.GetAllClientDeposits(SelectedPhysicalPersonClient.Id);
                creditsWindow.ShowDialog();
            }
        }

        private void ShowAllLegalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var creditsWindow = new CreditsWindow();
            creditsWindow.Title = $"Все кредиты клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                creditsWindow.CreditsDataGrid.DataContext = repo.GetAllClientDeposits(SelectedLegalPersonClient.Id);
                creditsWindow.ShowDialog();
            }
        }

        private void ShowAllPhysicalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var depositsWindow = new DepositsWindow();
            depositsWindow.Title = $"Все деопзиты клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                depositsWindow.DepositsDataGrid.DataContext = repo.GetAllClientDeposits(SelectedPhysicalPersonClient.Id);
                depositsWindow.ShowDialog();
            }
        }
        private void ShowAllLegalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var depositsWindow = new DepositsWindow();
            depositsWindow.Title = $"Все деопзиты клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                depositsWindow.DepositsDataGrid.DataContext = repo.GetAllClientDeposits(SelectedLegalPersonClient.Id);
                depositsWindow.ShowDialog();
            }
        }

        private void ShowAllPhysicalPersonAccountsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var accountsWindow = new AccountsWindow(SelectedPhysicalPersonClient.Id);
            accountsWindow.Title = $"Все счета клиента: {SelectedPhysicalPersonClient.DisplayName}";
            using (var repo = new PhysicalPersonClientRepository())
            {
                //accountsWindow.AccountsDataGrid.DataContext = repo.GetAllClientAccounts(SelectedPhysicalPersonClient.Id);
                accountsWindow.ShowDialog();
            }
        }

        private void ShowAllLegalPersonAccountsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var accountsWindow = new AccountsWindow(SelectedLegalPersonClient.Id);
            accountsWindow.Title = $"Все счета клиента: {SelectedLegalPersonClient.DisplayName}";
            using (var repo = new LegalPersonClientRepository())
            {
                //accountsWindow.AccountsDataGrid.DataContext = repo.GetAllClientAccounts(SelectedLegalPersonClient.Id);
                accountsWindow.ShowDialog();
            }
        }
    }
}
