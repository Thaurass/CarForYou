using AppProcessing;

namespace Interface.ViewModel
{
    internal class CarCardViewModel : ViewModelBase
    {
        private AdvertisementElement currentCar;

        public CarCardViewModel()
        {
            CurrentCar = CarAdvertisements.Instance.Cars[FeedViewModel.Instance.SelectedIndex];

            if (PersonCollection.Instance.CurrentSession.Login != CurrentCar.AuthorLogin) 
            {
                CurrentCar.Views++;
                CarAdvertisements.Instance.UpdateOneCar(CurrentCar);
            }

        }

        public AdvertisementElement CurrentCar
        {
            set { SetProperty(ref currentCar, value); }
            get { return currentCar; }
        }
    }
}
