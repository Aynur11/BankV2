using System.Windows;

namespace Bank.DesktopClient.LegalPersonClientWindow
{
    /// <summary>
    /// Interaction logic for AddingLegalPersonClientWindow.xaml
    /// </summary>
    public partial class AddingLegalPersonClientWindow : Window
    {
        public AddingLegalPersonClientWindow()
        {
            InitializeComponent();
            DataContext = new AddingLegalPersonClientViewModel();
        }
    }
}
