using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class CarCardViewModel : ViewModelBase
    {
        private AdvertisementElement currentCar;
        bool isVisible;
        string notification;

        public CarCardViewModel()
        {
            CurrentCar = CarAdvertisements.Instance.Cars[FeedViewModel.Instance.SelectedIndex];

            if (PersonCollection.Instance.CurrentSession.Login != CurrentCar.AuthorLogin) 
            {
                IsVisible = false;
                CurrentCar.Views++;
                CarAdvertisements.Instance.UpdateOneCar(CurrentCar);

            }
            else
            {
                IsVisible = true;
                DeleteCommand = new Command(
                execute: () =>
                {
                    CarAdvertisements.Instance.DeleteOneCar(CurrentCar);
                    IsVisible = false;
                    Notification = "Объявление удалено";
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return IsVisible;
                });
            }

            
        }

        void RefreshCanExecutes()
        {
            (DeleteCommand as Command).ChangeCanExecute();
        }

        public string Notification
        {
            set { SetProperty(ref notification, value); }
            get { return notification; }
        }

        public bool IsVisible
        {
            private set { SetProperty(ref isVisible, value); }
            get { return isVisible; }
        }

        public AdvertisementElement CurrentCar
        {
            set { SetProperty(ref currentCar, value); }
            get { return currentCar; }
        }

        public ICommand DeleteCommand { private set; get; }
    }
}
