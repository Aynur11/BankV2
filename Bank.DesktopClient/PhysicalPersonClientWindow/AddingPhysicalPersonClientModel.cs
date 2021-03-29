using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Bank.DesktopClient.Annotations;

namespace Bank.DesktopClient.PhysicalPersonClientWindow
{
    public class AddingPhysicalPersonClientModel : INotifyPropertyChanged
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime birthday;
        private bool isVip;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public bool IsVip
        {
            get => isVip;
            set
            {
                isVip = value;
                OnPropertyChanged(nameof(IsVip));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}