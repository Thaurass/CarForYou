using AppProcessing;
using System.Windows.Input;

namespace Interface.ViewModel
{
    public class FeedViewModel : ViewModelBase
    {
        private static FeedViewModel? _instance;
        public static FeedViewModel Instance => _instance ??= new FeedViewModel();

        public ICommand _refreshCommand;

        private IList<AdvertisementElement> advertisements { get; set; }
        private Timer timer;
        private int selectedIndex;

        public IList<AdvertisementElement> Advertisements
        {
            get => advertisements;
            set
            {
                if (advertisements != value)
                {
                    advertisements = value;
                    OnPropertyChanged();
                }
            }
        }

        public FeedViewModel()
        {
            
            CarAdvertisements.Instance.updateAllCars();
            this.Advertisements = CarAdvertisements.Instance.Cars;

            // Update the DateTime property every second.
            timer = new Timer(new TimerCallback((s) => this.Advertisements = CarAdvertisements.Instance.Cars),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public int SelectedIndex
        {
            private set { SetProperty(ref selectedIndex, value); }
            get { return selectedIndex; }
        }

        ~FeedViewModel() =>
            timer.Dispose();

        public void SelectCar(int index)
        {
            SelectedIndex = index;
            Shell.Current.GoToAsync("CarCardPage");
        }
    }
}
