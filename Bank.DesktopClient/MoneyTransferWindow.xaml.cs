using Bank.Dal.Accounts;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for MoneyTransferWindow.xaml
    /// </summary>
    public partial class MoneyTransferWindow : Window
    {
        /// <summary>
        /// Флаг для формирования списка счетов.
        /// </summary>
        private bool shouldRecipientAccountsHandle = true;

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
            if (Amount == 0 || SenderAccountIdComboBox.SelectedItem == null || RecipientAccountsIdComboBox.SelectedItem == null)
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

        private void SetRecipientAccountsId()
        {
            var client = (IHasAccounts)RecipientClientNamesComboBox.SelectedValue;
            RecipientAccountsIdComboBox.ItemsSource = client.GetAccounts();
            RecipientAccountsIdComboBox.DisplayMemberPath = "Id";
        }

        private void RecipientClientNamesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            shouldRecipientAccountsHandle = !cmb.IsDropDownOpen;
            if (RecipientClientNamesComboBox.SelectedItem != null)
            {
                Debug.WriteLine("RecipientClientNamesComboBox_OnSelectionChanged");
                Debug.WriteLine(RecipientClientNamesComboBox.SelectedValue.ToString());
                SetRecipientAccountsId();
            }
        }

        private void RecipientClientNamesComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            if (shouldRecipientAccountsHandle && RecipientClientNamesComboBox.SelectedValue != null)
            {
                Debug.WriteLine("RecipientClientNamesComboBox_OnDropDownClosed");

                SetRecipientAccountsId();
            }
        }

    }
}