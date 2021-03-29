using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Bank.DesktopClient.PhysicalPersonClientWindow
{
    public class AddingPhysicalPersonClientViewModel : INotifyPropertyChanged
    {
        private AddingPhysicalPersonClientModel client;

        public AddingPhysicalPersonClientModel Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
                Debug.WriteLine($"client name is {client.FirstName}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Click()
        {

        }

    }
}