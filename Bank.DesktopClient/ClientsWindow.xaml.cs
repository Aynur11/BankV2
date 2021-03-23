﻿using Bank.Bll;
using Bank.Dal;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;
using Bank.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            //TestData testData = new TestData();
            //testData.FillAllTables();

            using (var repo = new PhysicalPersonClientRepository())
            {
                PhysicalPersonsDataGrid.ItemsSource = repo.GetClients();
            }

            using (var repo = new LegalPersonClientRepository())
            {
                LegalPersonsDataGrid.ItemsSource = repo.GetClients();
            }
        }
        private void OpenPhysicalPersonAccountButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddingAnyAccountWindow accountWindow = new AddingAnyAccountWindow();
            accountWindow.CapitalizationCheckBox.IsEnabled = false;
            accountWindow.PeriodTextBox.IsEnabled = false;
            if (PhysicalPersonsDataGrid.CurrentItem != null)
            {
                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                accountWindow.ShowDialog();
                using (var repo = new PhysicalPersonClientRepository())
                {
                    repo.AddAccount(client.Id, accountWindow.Currency, accountWindow.Amount);
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
                accountWindow.ShowDialog();
                using (var repo = new LegalPersonClientRepository())
                {
                    repo.AddAccount(client.Id, accountWindow.Currency, accountWindow.Amount);
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
                accountWindow.ShowDialog();
                using (var repo = new PhysicalPersonClientRepository())
                {
                    repo.AddDeposit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period, accountWindow.WithCapitalization, Rate.CalcPhysicalPersonDepositRate(client.Type));
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
                accountWindow.ShowDialog();
                using (var repo = new LegalPersonClientRepository())
                {
                    repo.AddDeposit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period, accountWindow.WithCapitalization, Rate.CalcLegalPersonDepositRate(client.Type));
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
                accountWindow.ShowDialog();
                using (var repo = new PhysicalPersonClientRepository())
                {
                    repo.AddCredit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period, Rate.CalcPhysicalPersonCreditRate(client.Type));
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
                accountWindow.ShowDialog();
                using (var repo = new LegalPersonClientRepository())
                {
                    repo.AddCredit(client.Id, accountWindow.Currency, accountWindow.Amount, accountWindow.Period, Rate.CalcLegalPersonCreditRate(client.Type));
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
                //moneyTransferWindow.PhysicalClientNamesComboBox.ItemsSource = physicalPersonClientRepo.GetClientNamesWithId();
                //moneyTransferWindow.RecipientClientNamesComboBox.ItemsSource = legalPersonClientRepo.GetClientNamesWithId();

                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = physicalPersonClientRepo.GetAllClientAccountsId(client.Id);

                var allClients = new List<IClient>();
                allClients.AddRange(physicalPersonClientRepo.GetClients());
                allClients.AddRange(legalPersonClientRepo.GetClients());

                moneyTransferWindow.RecipientClientNamesComboBox.ItemsSource = allClients;
                moneyTransferWindow.RecipientClientNamesComboBox.DisplayMemberPath = "DisplayName";

                if (moneyTransferWindow.ShowDialog() == true)
                {
                    //bool isPhysicalRecipient = moneyTransferWindow.PhysicalClientNamesComboBox.IsEnabled;
                    //object recipientClient = isPhysicalRecipient ?
                    //    moneyTransferWindow.PhysicalClientNamesComboBox.SelectedValue :
                    //    moneyTransferWindow.RecipientClientNamesComboBox.SelectedValue;
                    //int recipientClientId = ((KeyValuePair<int, string>)recipientClient).Key;

                    //// Объект, выполняющий перевод.
                    //IClient clientFrom = physicalPersonClientRepo.GetClient(client.Id);
                    //IClient clientTo = isPhysicalRecipient ?
                    //     (IClient)physicalPersonClientRepo.GetClient(recipientClientId) :
                    //    legalPersonClientRepo.GetClient(recipientClientId);

                    try
                    {
                        AccountManager accountManager = new AccountManager();
                        //IAccount accountFrom = clientFrom.Accounts
                        //    .FirstOrDefault(i => i.Id == (int)moneyTransferWindow.SenderAccountIdComboBox.SelectedItem);
                        //IAccount accountTo = clientTo.Accounts.FirstOrDefault(i => i.Id == recipientClientId);
                        //accountManager.TransferMoney(accountFrom, accountTo, moneyTransferWindow.Amount);
                        //physicalPersonClientRepo.TransferMoney(client.Id,
                        //    (int) moneyTransferWindow.SenderAccountIdComboBox.SelectedItem,
                        //    purposeClientId, (int) moneyTransferWindow.RecipientAccountsIdComboBox.SelectedItem,
                        //    moneyTransferWindow.Amount);
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
                moneyTransferWindow.RecipientClientNamesComboBox.ItemsSource = legalPersonClientRepo.GetClientNamesWithId();

                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                moneyTransferWindow.SenderAccountIdComboBox.ItemsSource = legalPersonClientRepo.GetAllClientAccountsId(client.Id);

                if (moneyTransferWindow.ShowDialog() == true)
                {
                    //object recipientClient = moneyTransferWindow.PhysicalClientNamesComboBox.IsEnabled ?
                    //    moneyTransferWindow.PhysicalClientNamesComboBox.SelectedValue :
                    //    moneyTransferWindow.RecipientClientNamesComboBox.SelectedValue;
                    //int purposeClientId = ((KeyValuePair<int, string>)recipientClient).Key;
                    try
                    {
                        //legalPersonClientRepo.TransferMoney(client.Id, (int)moneyTransferWindow.SenderAccountIdComboBox.SelectedItem,
                        //    purposeClientId, (int)moneyTransferWindow.RecipientAccountsIdComboBox.SelectedItem, moneyTransferWindow.Amount);
                    }
                    catch (InsufficientAmountsException exception)
                    {
                        MessageBox.Show(
                            $"Произошла ошибка: {exception.Message}\nСуммма денег на счету: {exception.Amount}");
                    }
                    catch (CurrencyMismatchException exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}\n" +
                                        $"Валюта счета отправителя: {exception.Sender}, валюта счета получателя: {exception.Recipient}");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Произошла ошибка: {exception.Message}. Выполняем завершение программы.");
                        throw;
                    }
                }
            }
        }

        private void AddNewPhysicalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemovePhysicalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowAllPhysicalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowAllPhysicalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void PhysicalPersonsDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void PhysicalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void LeaglPersonsDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void LegalPersonsDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }



        private void RemoveLegalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewLegalPersonClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowAllLegalPersonCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowAllLegalPersonDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
