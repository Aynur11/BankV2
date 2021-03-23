using Bank.Dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Bank.Dal.Clients;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for MoneyTransferWindow.xaml
    /// </summary>
    public partial class MoneyTransferWindow : Window
    {
        public MoneyTransferWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сумма денег на счету клиента.
        /// </summary>
        public decimal Amount => AddingAnyAccountWindow.IsDecimal(AmountTextBox.Text) ? Convert.ToDecimal(AmountTextBox.Text) : 0;

        private void SumTextBox_OnGotFocusTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            AmountTextBox.Text = String.Empty;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Amount == 0  || SenderAccountIdComboBox.SelectedItem == null || RecipientAccountsIdComboBox.SelectedItem == null)
            {
                MessageBox.Show("Введите корректные данные!");
                return;
            }
            DialogResult = true;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LegalClientNamesComboBox_OnIsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private bool legalRecipientsHandle = true;

        private void SetLegalRecipientAccountsId()
        {
            using (var repo = new LegalPersonClientRepository())
            {
                Debug.WriteLine($"selected value:{((IClient)RecipientClientNamesComboBox.SelectedValue).DisplayName}");

                var client = RecipientClientNamesComboBox.SelectedValue is PhysicalPersonClient
                    ? (IClient) RecipientClientNamesComboBox.SelectedValue
                    : (IClient) RecipientClientNamesComboBox.SelectedValue;
                //RecipientAccountsIdComboBox.ItemsSource = client.
            }
        }

        private void LegalClientNamesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            legalRecipientsHandle = !cmb.IsDropDownOpen;
            if (RecipientClientNamesComboBox.SelectedItem != null)
            {
                Debug.WriteLine("LegalClientNamesComboBox_OnSelectionChanged");
                Debug.WriteLine(RecipientClientNamesComboBox.SelectedValue.ToString());
                SetLegalRecipientAccountsId();
            }
        }

        private void LegalClientNamesComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            if (legalRecipientsHandle && RecipientClientNamesComboBox.SelectedValue != null)
            {
                Debug.WriteLine("LegalClientNamesComboBox_OnDropDownClosed");

                SetLegalRecipientAccountsId();
            }
        }

    }
}