
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class AdvertiseViewModel : INotifyPropertyChanged
    {
        AdvertisementElement carEdit;
        bool isEditing;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdvertiseViewModel()
        {
            NewCommand = new Command(
                execute: () =>
                {
                    CarEdit = new AdvertisementElement();
                    CarEdit.PropertyChanged += OnPersonEditPropertyChanged;
                    IsEditing = true;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !IsEditing;
                });
            SubmitCommand = new Command(
                execute: () =>
                {
                    CarEdit.PropertyChanged -= OnPersonEditPropertyChanged;
                    CarAdvertisements.Instance.Cars.Add(CarEdit);
                    CarEdit = null;
                    IsEditing = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return CarEdit != null &&
                           CarEdit.Name != null &&
                           CarEdit.Name.Length > 1 &&
                           CarEdit.Price != null &&
                           CarEdit.CarType != null &&
                           CarEdit.MileAge != null;
                });
            CancelCommand = new Command(
                execute: () =>
                {
                    CarEdit.PropertyChanged -= OnPersonEditPropertyChanged;
                    CarEdit = null;
                    IsEditing = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return IsEditing;
                });
        }

        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (SubmitCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (NewCommand as Command).ChangeCanExecute();
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
        }

        public bool IsEditing
        {
            private set { SetProperty(ref isEditing, value); }
            get { return isEditing; }
        }

        public AdvertisementElement CarEdit
        {
            set { SetProperty(ref carEdit, value); }
            get { return carEdit; }
        }

        public ICommand NewCommand { private set; get; }

        public ICommand SubmitCommand { private set; get; }

        public ICommand CancelCommand { private set; get; }


        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
