
using System.ComponentModel;
using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class AdvertiseViewModel : ViewModelBase
    {
        AdvertisementElement carEdit;
        bool isEditing;
        string[] names = { "Lada Vesta", "Opel Vectra", "Reno Megan", "Range Rover", "Reno Logan", "Lada Largus"};
        string[] carTypes = { "SUV", "Sedan", "Hatchback" };
        Random random = new Random();

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
                    CarEdit.AuthorLogin = PersonCollection.Instance.CurrentSession.Login;
                    CarEdit.PropertyChanged -= OnPersonEditPropertyChanged;
                    CarAdvertisements.Instance.AddCar(CarEdit);
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
                           CarEdit.Price.Length > 0 &&
                           IsInt(CarEdit.Price) &&
                           CarEdit.CarType != null &&
                           CarEdit.CarType.Length > 0 &&
                           CarEdit.MileAge != null &&
                           CarEdit.MileAge.Length > 1 &&
                           IsInt(CarEdit.MileAge);
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
            FillCommand = new Command(
                execute: () =>
                {
                    CarEdit.Name = names[random.Next(names.Length)];
                    CarEdit.Price = random.Next(100000, 10000000).ToString();
                    CarEdit.MileAge = random.Next(1000, 1000000).ToString();
                    CarEdit.CarType = carTypes[random.Next(carTypes.Length)];
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return IsEditing;
                });
        }

        bool IsInt(string number)
        {
            int verifyedNumber;
            bool isNumber = int.TryParse(number, out verifyedNumber);
            return isNumber;
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
            (FillCommand as Command).ChangeCanExecute();
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
        public ICommand FillCommand { private set; get; }

    }
}
