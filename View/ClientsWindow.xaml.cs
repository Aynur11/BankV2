﻿using System;
using Controller;
using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public Tables Tables;
        public ClientsWindow()
        {
            InitializeComponent();
            //TestData testData = new TestData();
            //testData.FillAllTables();

            Tables = new Tables();
            PhysicalPersonsDataGrid.ItemsSource = Tables.PhysicalPersonClients;
            LegalPersonsDataGrid.ItemsSource = Tables.LegalPersonClients;
        }
        private void OpenAccountButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenDepositButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void IssueCreditButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void TransferMoneyButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddNewClientButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowAllCreditsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowAllDepositsMenuItem_OnClick(object sender, RoutedEventArgs e)
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
    }
}
