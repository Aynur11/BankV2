using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Bank.DesktopClient.PhysicalPersonClientWindow;

namespace Bank.DesktopClient.LegalPersonClientWindow
{
    public class AddingLegalPersonClientViewModel
    {
        private RelayCommand okClickRelayCommand;
        private RelayCommand cancelClickRelayCommand;
        private RelayCommand gotFocusCommand;

        public RelayCommand OkClickCommand
        {
            get
            {
                return okClickRelayCommand ?? (okClickRelayCommand = new RelayCommand(o =>
                {
                    Window window = (Window)o;
                    window.DialogResult = true;
                    window.Close();
                }));
            }
        }

        public RelayCommand CancelClickCommand
        {
            get
            {
                return cancelClickRelayCommand ?? (cancelClickRelayCommand = new RelayCommand(o =>
                {
                    Window window = (Window)o;
                    window.DialogResult = false;
                    window.Close();
                }));
            }
        }

        public RelayCommand GotFocusCommand
        {
            get { return gotFocusCommand ?? (gotFocusCommand = new RelayCommand(o => { ((TextBox)o).Clear(); })); }
        }
    }
}
