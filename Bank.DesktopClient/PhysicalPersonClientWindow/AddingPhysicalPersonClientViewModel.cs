using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Bank.DesktopClient.PhysicalPersonClientWindow
{
    public class AddingPhysicalPersonClientViewModel : INotifyPropertyChanged
    {
        //private AddingPhysicalPersonClientModel client;
        private RelayCommand okClickRelayCommand;
        private RelayCommand cancelClickRelayCommand;
        private RelayCommand gotFocusCommand;

        public RelayCommand OkClickCommand =>
            okClickRelayCommand ?? (okClickRelayCommand = new RelayCommand(o =>
            {
                Window window = (Window) o;
                window.DialogResult = true;
                window.Close();
            }));

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
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}