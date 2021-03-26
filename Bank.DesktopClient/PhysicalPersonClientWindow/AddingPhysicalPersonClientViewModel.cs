using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bank.DesktopClient.PhysicalPersonClientWindow
{
    public class AddingPhysicalPersonClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Click()
        {

        }

    }
}