using AppProcessing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Interface.Pages;

public partial class Feed : ContentPage
{

    public Feed()
	{

        InitializeComponent();
	}

}

class GetCarData : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private List<Advertisement> _advertisements { get; set; }
    private Timer _timer;

    public List<Advertisement> Advertisements
    {
        get => _advertisements;
        set
        {
            if (_advertisements != value)
            {
                _advertisements = value;
                OnPropertyChanged(); // reports this property
            }
        }
    }

    public GetCarData()
    {
        this.Advertisements = CarAdvertisements.Advertisements;

        // Update the DateTime property every second.
        _timer = new Timer(new TimerCallback((s) => this.Advertisements = CarAdvertisements.Advertisements),
                           null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
    }

    ~GetCarData() =>
        _timer.Dispose();

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}