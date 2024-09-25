using AppProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface.ViewModel
{
    internal class FeedViewModel : INotifyPropertyChanged
    {
        public ICommand _refreshCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        private IList<AdvertisementElement> _advertisements { get; set; }
        private Timer _timer;

        public IList<AdvertisementElement> Advertisements
        {
            get => _advertisements;
            set
            {
                if (_advertisements != value)
                {
                    _advertisements = value;
                    OnPropertyChanged();
                }
            }
        }

        public FeedViewModel()
        {
            this.Advertisements = CarAdvertisements.Instance.Cars;

            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => this.Advertisements = CarAdvertisements.Instance.Cars),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        ~FeedViewModel() =>
            _timer.Dispose();

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
