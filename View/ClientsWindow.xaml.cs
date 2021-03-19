using Bank.BLL;
using Bank.DAL.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ClientNameWindow clientNameWindow = new ClientNameWindow();
            using (var physicalPersonClientRepo = new PhysicalPersonClientRepository())
            using (var legalPersonClientRepo = new LegalPersonClientRepository())
            {
                clientNameWindow.PhysicalClientNamesComboBox.ItemsSource = physicalPersonClientRepo.GetClientNamesWithId();
                clientNameWindow.LegalClientNamesComboBox.ItemsSource = legalPersonClientRepo.GetClientNamesWithId();

                PhysicalPersonClient client = (PhysicalPersonClient)PhysicalPersonsDataGrid.SelectedItem;
                clientNameWindow.SenderAccountIdComboBox.ItemsSource = physicalPersonClientRepo.GetAllClientAccountsId(client.Id);

                if (clientNameWindow.ShowDialog() == true)
                {
                    object recipientClient = clientNameWindow.PhysicalClientNamesComboBox.IsEnabled ?
                        clientNameWindow.PhysicalClientNamesComboBox.SelectedValue :
                        clientNameWindow.LegalClientNamesComboBox.SelectedValue;
                    int purposeClientId = ((KeyValuePair<int, string>)recipientClient).Key;
                    physicalPersonClientRepo.TransferMoney(client.Id, (int)clientNameWindow.SenderAccountIdComboBox.SelectedItem,
                        purposeClientId, (int)clientNameWindow.RecipientAccountsIdComboBox.SelectedItem, clientNameWindow.Amount);
                }
            }
        }

        private void TransferLegalPersonMoneyButton_OnClick(object sender, RoutedEventArgs e)
        {
            ClientNameWindow clientNameWindow = new ClientNameWindow();
            using (var physicalPersonClientRepo = new PhysicalPersonClientRepository())
            using (var legalPersonClientRepo = new LegalPersonClientRepository())
            {
                clientNameWindow.PhysicalClientNamesComboBox.ItemsSource = physicalPersonClientRepo.GetClientNamesWithId();
                clientNameWindow.LegalClientNamesComboBox.ItemsSource = legalPersonClientRepo.GetClientNamesWithId();

                LegalPersonClient client = (LegalPersonClient)LegalPersonsDataGrid.SelectedItem;
                clientNameWindow.SenderAccountIdComboBox.ItemsSource = legalPersonClientRepo.GetAllClientAccountsId(client.Id);

                if (clientNameWindow.ShowDialog() == true)
                {
                    object recipientClient = clientNameWindow.PhysicalClientNamesComboBox.IsEnabled ?
                        clientNameWindow.PhysicalClientNamesComboBox.SelectedValue :
                        clientNameWindow.LegalClientNamesComboBox.SelectedValue;
                    int purposeClientId = ((KeyValuePair<int, string>)recipientClient).Key;
                    legalPersonClientRepo.TransferMoney(client.Id, (int)clientNameWindow.SenderAccountIdComboBox.SelectedItem,
                        purposeClientId, (int)clientNameWindow.RecipientAccountsIdComboBox.SelectedItem, clientNameWindow.Amount);
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
