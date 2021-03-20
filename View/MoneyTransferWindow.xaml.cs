using Bank.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for ClientNameWindow.xaml
    /// </summary>
    public partial class ClientNameWindow : Window
    {
        public ClientNameWindow()
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

        private void PhysicalClientNamesComboBox_OnIsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LegalClientNamesComboBox.IsEnabled = false;
        }

        private void LegalClientNamesComboBox_OnIsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PhysicalClientNamesComboBox.IsEnabled = false;
        }

        private void EnableComboboxesButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LegalClientNamesComboBox.IsEnabled = true;
            PhysicalClientNamesComboBox.IsEnabled = true;
            LegalClientNamesComboBox.SelectedItem = null;
            PhysicalClientNamesComboBox.SelectedItem = null;
            RecipientAccountsIdComboBox.SelectedItem = null;
        }

        private bool physicalRecipientsHandle = true;
        private bool legalRecipientsHandle = true;

        private void PhysicalClientNamesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            physicalRecipientsHandle = !cmb.IsDropDownOpen;
            if (PhysicalClientNamesComboBox.SelectedItem != null)
            {
                Debug.WriteLine("PhysicalClientNamesComboBox_OnSelectionChanged");
                SetPhysicalRecipientAccountsId();
            }
        }
        
        private void PhysicalClientNamesComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            if (physicalRecipientsHandle && PhysicalClientNamesComboBox.SelectedValue != null)
            {
                Debug.WriteLine("PhysicalClientNamesComboBox_OnDropDownClosed");
                SetPhysicalRecipientAccountsId();
            }
            physicalRecipientsHandle = true;
        }

        private void SetPhysicalRecipientAccountsId()
        {
            using (var repo = new PhysicalPersonClientRepository())
            {
                int purposeClientId = ((KeyValuePair<int, string>) PhysicalClientNamesComboBox.SelectedValue).Key;
                RecipientAccountsIdComboBox.ItemsSource =
                    repo.GetAllClientAccountsId(purposeClientId);
            }
        }


        private void SetLegalRecipientAccountsId()
        {
            using (var repo = new LegalPersonClientRepository())
            {
                int purposeClientId = ((KeyValuePair<int, string>)LegalClientNamesComboBox.SelectedValue).Key;
                RecipientAccountsIdComboBox.ItemsSource =
                    repo.GetAllClientAccountsId(purposeClientId);
            }
        }

        private void LegalClientNamesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            legalRecipientsHandle = !cmb.IsDropDownOpen;
            if (LegalClientNamesComboBox.SelectedItem != null)
            {
                Debug.WriteLine("LegalClientNamesComboBox_OnSelectionChanged");
                Debug.WriteLine(LegalClientNamesComboBox.SelectedValue.ToString());
                SetLegalRecipientAccountsId();
            }
        }

        private void LegalClientNamesComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            if (legalRecipientsHandle && LegalClientNamesComboBox.SelectedValue != null)
            {
                Debug.WriteLine("LegalClientNamesComboBox_OnDropDownClosed");

                SetLegalRecipientAccountsId();
            }
            physicalRecipientsHandle = true;
        }

    }
}