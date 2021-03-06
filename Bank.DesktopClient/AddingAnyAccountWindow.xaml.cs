using System;
using System.Windows;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient
{
    /// <summary>
    /// Interaction logic for AddingAnyAccountWindow.xaml
    /// </summary>
    public partial class AddingAnyAccountWindow : Window
    {
        public AddingAnyAccountWindow()
        {
            InitializeComponent();
            Title = "Данные для открытия/выдачи вклада/кредита";
            CurrenciesComboBox.ItemsSource = Enum.GetValues(typeof(Currency));
            CurrenciesComboBox.SelectedValue = Dal.Accounts.Currency.Rub;
        }

        /// <summary>
        /// Сумма денег с проверкой коррекности ввода.
        /// </summary>
        public decimal Amount => IsDecimal(SumTextBox.Text) ? Convert.ToDecimal(SumTextBox.Text) : 0;

        /// <summary>
        /// Период ведения счета с проверкой корректности ввода.
        /// </summary>
        public int Period => PeriodTextBox.IsEnabled && IsDouble(PeriodTextBox.Text) ? Convert.ToInt32(PeriodTextBox.Text) : 0;

        /// <summary>
        /// Выбранная валюта.
        /// </summary>
        public Currency Currency => (Currency) CurrenciesComboBox.SelectedItem;

        /// <summary>
        /// С капитализацией?
        /// </summary>
        public bool WithCapitalization => CapitalizationCheckBox.IsEnabled;

        /// <summary>
        /// Предварительная проверка что значение является типом Double.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Булевыйй результат.</returns>
        public static bool IsDouble(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return double.TryParse(text, out _);
        }

        /// <summary>
        /// Предварительная проверка что значение является типом Double.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Булевыйй результат.</returns>
        public static bool IsDecimal(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return decimal.TryParse(text, out _);
        }

        /// <summary>
        /// Очистка текст-бокса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SumTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            SumTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Очистка текст-бокса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeriodTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PeriodTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия на ОК.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Amount == 0 || PeriodTextBox.IsEnabled && Period == 0)
            {
                MessageBox.Show("Введите корректные данные!");
                return;
            }
            this.DialogResult = true;
        }

        /// <summary>
        /// Обработчик нажатия на отмену.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
