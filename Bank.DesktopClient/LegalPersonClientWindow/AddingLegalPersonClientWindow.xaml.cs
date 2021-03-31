using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
